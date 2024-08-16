using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Типография
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            Form2 Цехи = new Form2();
            Цехи.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 Продукция = new Form3();
            Продукция.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 Договоры = new Form4();
            Договоры.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 Заказы = new Form5();
            Заказы.Show();
        }
    }
}
