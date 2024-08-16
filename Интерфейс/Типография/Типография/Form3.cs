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
    public partial class Form3 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "типографияDataSet.Цехи". При необходимости она может быть перемещена или удалена.
            this.цехиTableAdapter.Fill(this.типографияDataSet.Цехи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "типографияDataSet1.Продукция". При необходимости она может быть перемещена или удалена.
            this.продукцияTableAdapter.Fill(this.типографияDataSet1.Продукция);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["printinghouse"].ConnectionString);
            sqlConnection.Open();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.продукцияTableAdapter.Fill(this.типографияDataSet1.Продукция);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Продукция] VALUES(@код_продукции, @название_продукции, @номер_цеха,@стоимость_единицы_печатной_продукции_руб)", sqlConnection);
            command.Parameters.AddWithValue("код_продукции", textBox5.Text);
            command.Parameters.AddWithValue("название_продукции", textBox6.Text);
            command.Parameters.AddWithValue("номер_цеха", comboBox1.Text);
            command.Parameters.AddWithValue("стоимость_единицы_печатной_продукции_руб", textBox7.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Добавлено");
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Заказы WHERE код_продукции=@код_продукции", sqlConnection);
            command.Parameters.AddWithValue("код_продукции", comboBox2.Text);
            command.ExecuteNonQuery();
            command = new SqlCommand("DELETE FROM Продукция WHERE код_продукции=@код_продукции", sqlConnection);
            command.Parameters.AddWithValue("код_продукции", comboBox2.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Удалено");
            comboBox2.Text = "";

        }
    }
}
