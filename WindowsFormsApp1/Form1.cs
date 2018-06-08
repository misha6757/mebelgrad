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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "polDataSet1.customer". При необходимости она может быть перемещена или удалена.
            this.customerTableAdapter.Fill(this.polDataSet1.customer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idK = "";
            string FIO = "";
            string adress = "";
            string phone = "";
            string sum = "";
            idK = Convert.ToString(textBox1.Text);
            FIO = Convert.ToString(textBox2.Text);
            adress = Convert.ToString(textBox3.Text);
            phone = Convert.ToString(textBox4.Text);
            sum = "('" + idK + "', '" + FIO + "', '" + adress + "', '" + phone + "')";
            customerTableAdapter.Connection.Open();
            OleDbCommand command = customerTableAdapter.Connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO customer (idcust, firstname, lastname, phone) VALUES " + sum;
            command.ExecuteNonQuery();
            customerTableAdapter.Connection.Close();
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;
            Data Source=C:\WindowsFormsApp1\WindowsFormsApp1\pol.mdb;Persist Security Info=False");
            conn.Open();
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Клиент добавлен");
            customerTableAdapter.Update(polDataSet1.customer);
            customerTableAdapter.Fill(polDataSet1.customer);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
        }
    }
}
