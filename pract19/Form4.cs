using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract19
{
    public partial class Form4 : Form
    {
        Cezar cezar = new Cezar();
        List<string[]> spisok = new List<string[]>();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            StreamReader sw = File.OpenText("itogi.txt");
            int i = 0, j;
            while (!sw.EndOfStream)
            {
                string[] mas = new string[3];
                string str = sw.ReadLine(); 
                str=cezar.Deshifr(str);
                int test = str.IndexOf(' ');
                string str2 = str;
                mas[0]=str.Remove(test);
                str2 = str.Remove(0,str.IndexOf(' ') +1);
                mas[1]=str2.Remove(str2.IndexOf(' '));
                str2 = str2.Remove(0, str2.IndexOf(' ') + 7);
                mas[2] = str2.Remove(3);
                dataGridView1.Rows.Add(mas[0], mas[1], mas[2]);
                i++;
                spisok.Add(mas);
            }
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nado = textBox1.Text;
            dataGridView1.Rows.Clear();
            for(int i = 0;i<spisok.Count;i++) 
            {
                if (spisok[i][0] == nado || spisok[i][1] == nado) 
                {
                    dataGridView1.Rows.Add(spisok[i][0], spisok[i][1], spisok[i][2]);
                }
            }
        }

        private void dataGridView1_CancelRowEdit(object sender, QuestionEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i =0;i<dataGridView1.Rows.Count;i++) 
            {
                for(int j =0; j < 4; j++) 
                {
                    DataGridViewCell cell = dataGridView1.Rows[i].Cells[j];
                    spisok[i][j] = cell.ToString();
                }
            }
            StreamWriter sw=File.CreateText("itogi0.txt");
            for (int i = 0; i < spisok.Count; i++)
            {
                sw.WriteLine($"{spisok[i][0]} {spisok[i][1]} верно {spisok[i][2]}  вопросов из 16 возможных ");
            }
            sw.Close();
            button2.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Visible = true;
        }
    }
}
