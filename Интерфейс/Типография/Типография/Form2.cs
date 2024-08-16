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
    public partial class Form2 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            this.цехиTableAdapter.Fill(this.типографияDataSet.Цехи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "типографияDataSet1.Цехи". При необходимости она может быть перемещена или удалена.

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["printinghouse"].ConnectionString);
            sqlConnection.Open();
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Цехи] VALUES(@номер_цеха, @название_цеха, @начальник_цеха,@телефон_цеха)", sqlConnection);
            command.Parameters.AddWithValue("номер_цеха", textBox5.Text);
            command.Parameters.AddWithValue("название_цеха", textBox6.Text);
            command.Parameters.AddWithValue("начальник_цеха", textBox7.Text);
            command.Parameters.AddWithValue("телефон_цеха", textBox8.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Добавлено");
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.цехиTableAdapter.Fill(this.типографияDataSet.Цехи);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Продукция WHERE номер_цеха = @номер_цеха",sqlConnection);
            command.Parameters.AddWithValue("номер_цеха", comboBox1.Text);
            command.ExecuteNonQuery();
            command = new SqlCommand("DELETE FROM Цехи WHERE номер_цеха = @номер_цеха", sqlConnection);
            command.Parameters.AddWithValue("номер_цеха",comboBox1.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Удалено");
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Цехи WHERE номер_цеха = @номер_цеха OR название_цеха = @название_цеха OR начальник_цеха = @начальник_цеха OR телефон_цеха = @телефон_цеха", sqlConnection);
            command.Parameters.AddWithValue("номер_цеха", textBox5.Text);
            command.Parameters.AddWithValue("название_цеха", textBox6.Text);
            command.Parameters.AddWithValue("начальник_цеха", textBox7.Text);
            command.Parameters.AddWithValue("телефон_цеха", textBox8.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Удалено");
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
    }
}
