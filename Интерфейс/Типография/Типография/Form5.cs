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
    public partial class Form5 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "типографияDataSet1.Продукция". При необходимости она может быть перемещена или удалена.
            this.продукцияTableAdapter.Fill(this.типографияDataSet1.Продукция);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "типографияDataSet2.Договоры". При необходимости она может быть перемещена или удалена.
            this.договорыTableAdapter.Fill(this.типографияDataSet2.Договоры);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "типографияDataSet3.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.типографияDataSet3.Заказы);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["printinghouse"].ConnectionString);
            sqlConnection.Open();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.заказыTableAdapter.Fill(this.типографияDataSet3.Заказы);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Заказы] VALUES(@номер_договора, @код_продукции, @количество_продукции_шт)", sqlConnection);
            command.Parameters.AddWithValue("номер_договора", comboBox1.Text);
            command.Parameters.AddWithValue("код_продукции", comboBox2.Text);
            command.Parameters.AddWithValue("количество_продукции_шт", textBox5.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Добавлено");
            textBox5.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [Заказы] WHERE номер_договора=@номер_договора AND код_продукции=@код_продукции", sqlConnection);
            command.Parameters.AddWithValue("номер_договора", comboBox1.Text);
            command.Parameters.AddWithValue("код_продукции", comboBox2.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Удалено");
            textBox5.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
    }
}
