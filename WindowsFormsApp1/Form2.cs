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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "polDataSet3.mebel". При необходимости она может быть перемещена или удалена.
            this.mebelTableAdapter.Fill(this.polDataSet3.mebel);
            
           

        }

        private void label5_Click(object sender, EventArgs e)
        {

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
            mebelTableAdapter.Connection.Open();
            OleDbCommand command = mebelTableAdapter.Connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO mebel (idmeb, nazvanie, model,opis,chena) VALUES " + sum;
            command.ExecuteNonQuery();
            mebelTableAdapter.Connection.Close();
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;
            Data Source=C:\WindowsFormsApp1\WindowsFormsApp1\pol.mdb;Persist Security Info=False");
            conn.Open();
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Товар добавлен");
            mebelTableAdapter.Update(polDataSet3.mebel);
            mebelTableAdapter.Fill(polDataSet3.mebel);
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
        }
    }
}
