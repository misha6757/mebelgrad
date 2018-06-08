using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "polDataSet4.zakaz". При необходимости она может быть перемещена или удалена.
            this.zakazTableAdapter.Fill(this.polDataSet4.zakaz);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idK = "";
            string FIO = "";
            string adress = "";
            string phone = "";
            string phon = "";
            string sum = "";
            idK = Convert.ToString(textBox1.Text);
            FIO = Convert.ToString(textBox2.Text);
            adress = Convert.ToString(textBox3.Text);
            phone = Convert.ToString(textBox4.Text);
            phon = Convert.ToString(textBox5.Text);
            sum = "('" + idK + "', '" + FIO + "', '" + adress + "', '" + phone + "', '" + phon + "')";
            zakazTableAdapter.Connection.Open();
            OleDbCommand command = zakazTableAdapter.Connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO zakaz (idzak, idcust, idmeb,data,oplata) VALUES " + sum;
            command.ExecuteNonQuery();
            zakazTableAdapter.Connection.Close();
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;
            Data Source=C:\WindowsFormsApp1\WindowsFormsApp1\pol.mdb;Persist Security Info=False");
            conn.Open();
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Товар добавлен");
            zakazTableAdapter.Update(polDataSet4.zakaz);
            zakazTableAdapter.Fill(polDataSet4.zakaz);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;
             Data Source=C:\WindowsFormsApp1\WindowsFormsApp1\pol.mdb;Persist Security Info=False");
            conn.Open();
            OleDbDataAdapter zapros4 = new
               OleDbDataAdapter("SELECT zakaz.idzak, zakaz.idcust FROM zakaz WHERE oplata IN ('да');", conn);
            OleDbCommand command = new
                OleDbCommand("SELECT zakaz.idzak, zakaz.idcust FROM zakaz WHERE oplata IN ('да');", conn);
            zapros4.SelectCommand = command;
            DataTable DTzap4 = new DataTable();
            zapros4.Fill(DTzap4);
            BindingSource BSzap4 = new BindingSource();
            BSzap4.DataSource = DTzap4;
            dataGridView2.DataSource = BSzap4;
            //dataGridView2.Columns[0].HeaderCell.Value = "Максимальная стоимость";
            conn.Close();
            MessageBox.Show("Оплаченные заказ");
        }
    }
}
