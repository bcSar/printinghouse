using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Типография
{
    public partial class Form4 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "типографияDataSet2.Договоры". При необходимости она может быть перемещена или удалена.
            this.договорыTableAdapter.Fill(this.типографияDataSet2.Договоры);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["printinghouse"].ConnectionString);
            sqlConnection.Open();
            comboBox5.Text = "";
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.договорыTableAdapter.Fill(this.типографияDataSet2.Договоры);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Договоры] VALUES(@номер_договора, @название_заказчика, @адрес_заказчика,@дата_оформления_договора,@дата_выполнения_договора)", sqlConnection);
            command.Parameters.AddWithValue("номер_договора", textBox5.Text);
            command.Parameters.AddWithValue("название_заказчика", textBox6.Text);
            command.Parameters.AddWithValue("адрес_заказчика", textBox7.Text);
            command.Parameters.AddWithValue("дата_оформления_договора", textBox8.Text);
            command.Parameters.AddWithValue("дата_выполнения_договора", textBox9.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Добавлено");
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [Заказы] WHERE номер_договора=@номер_договора", sqlConnection);
            command.Parameters.AddWithValue("номер_договора", comboBox5.Text);
            command.ExecuteNonQuery();
            command = new SqlCommand("DELETE FROM [Договоры] WHERE номер_договора=@номер_договора", sqlConnection);
            command.Parameters.AddWithValue("номер_договора", comboBox5.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Удалено");
            comboBox5.Text = "";
        }

       
        
    }
}
