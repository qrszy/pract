using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract19
{
    public partial class Form2Reg : Form
    { int r = 0;
        public Form2Reg()
        {
            Form1 f1;
            Form3 f3;
            Form4 f4;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Form1 f1 = new Form1(textBox1.Text + " " + textBox2.Text);
                f1.ShowDialog();
            }
            else
            if(textBox3.Text != "" && textBox4.Text != "")
            {
                Form3 f3 = new Form3(textBox3.Text);
                f3.ShowDialog();
            }else MessageBox.Show("Заполните данные");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (r == 0)
            {
                label1.Visible = false; textBox1.Visible = false; textBox2.Visible = false; label2.Visible = false;
                label3.Visible = true; textBox3.Visible = true; label4.Visible = true; textBox4.Visible = true;
                button1.Text = "Войти";
                button2.Text = "Назад";
                r = 1;
            }
            else
                if (r == 1) 
            {
                label1.Visible = true; textBox1.Visible = true; textBox2.Visible = true; label2.Visible = true;
                label3.Visible = false; textBox3.Visible = false; label4.Visible = false; textBox4.Visible = false;
                button1.Text = "Начать тест";
                button2.Text = "Режим учителя";
                r = 0;
            }
        }

        
    }
}
