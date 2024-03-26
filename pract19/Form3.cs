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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pract19
{
    public partial class Form3 : Form
    {
        List<string> spisok = new List<string>();
        int strn = 0, max = 0;
        string filePath = "";
        Cezar cezar = new Cezar();
        public Form3(string name)
        {
           
            InitializeComponent();
            this.Name = name;
            StreamReader sw = File.OpenText("voprosi.txt");
            int i = 0, j;
            while (!sw.EndOfStream)
            {
                for (j = 0; j < 6; j++)
                {
                    string st = sw.ReadLine();
                    if (st!=null) { spisok.Add(cezar.Deshifr(st)); }
                    else spisok.Add("");
                }
                max++;
            }
            sw.Close();
            label8.Text = "Из " + $"{max}";
            label1.Text = "Вопос № " + (strn + 1);
            textBox1.Text = spisok[0];
            textBox2.Text = spisok[4];
            textBox3.Text = spisok[1];
            textBox4.Text = spisok[2];
            textBox5.Text = spisok[3];
            textBox6.Text = spisok[5];
            pictureBox1.Image = Image.FromFile($"{spisok[5]}");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            strn--;
            button4.Enabled = false;
            button2.Enabled = true;
            if (button3.Text != "Сохранить изменения") button3.Text = "Сохранить изменения";
            label1.Text = "Вопрос № " + (strn + 1);
            if (strn == 0) button1.Enabled = false;
            textBox1.Text = spisok[6 * strn + 0];
            textBox2.Text = spisok[6 * strn + 4];
            textBox3.Text = spisok[6 * strn + 1];
            textBox4.Text = spisok[6 * strn + 2];
            textBox5.Text = spisok[6 * strn + 3];
            textBox6.Text = spisok[6 * strn + 5];
            if (spisok[6 * strn + 5] != "") { pictureBox1.Visible = true; pictureBox1.Image = Image.FromFile($"{spisok[6 * strn + 5]}"); }
            else { pictureBox1.Visible = false; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            strn++;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Text = "Сохранить";
            button5.Visible = true;
            button5.Enabled = true;
            button4.Enabled = false;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                if (File.Exists($"{textBox6.Text}"))
                {
                    pictureBox1.Visible = true; pictureBox1.Image = Image.FromFile($"{textBox6.Text}");
                }
            }
            else pictureBox1.Visible = false;
            /*spisok[6 * strn + 5]*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (button3.Text == "Сохранить изменения")
            {
                spisok[6 * strn + 0] = textBox1.Text;
                spisok[6 * strn + 4] = textBox2.Text;
                spisok[6 * strn + 1] = textBox3.Text;
                spisok[6 * strn + 2] = textBox4.Text;
                spisok[6 * strn + 3] = textBox5.Text;
                if (spisok[6 * strn + 5] != "") { pictureBox1.Visible = true; pictureBox1.Image = Image.FromFile($"{spisok[6 * strn + 5]}"); }
                else { pictureBox1.Visible = false; }

            }
            else
                if (button3.Text == "Сохранить" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                spisok.Add(textBox1.Text);
                spisok.Add(textBox2.Text);
                spisok.Add(textBox3.Text);
                spisok.Add(textBox4.Text);
                spisok.Add(textBox5.Text);
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "(*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        string file_name = Path.GetFileName(filePath);
                        File.Copy(filePath,file_name,true);  
                        pictureBox1.Image = Image.FromFile(file_name);
                        textBox6.Text = file_name;
                        spisok.Add(file_name);
                    }
                }
                max++;
                button5.Visible = false;
            }
            StreamWriter sw = File.CreateText("voprosi.txt");

            for (int i = 0; i < spisok.Count; i++)
            {
                sw.WriteLine(cezar.Shifr(spisok[i]));
            }
            sw.Close();

        }
    

        private void button5_Click(object sender, EventArgs e)
        {
            strn--;
            button3.Text = "Сохранить изменения";
            button5.Visible = false;
            button5.Enabled = false;
            button4.Enabled = true;
            button1.Enabled = true;
            label1.Text = "Вопрос № " + (strn + 1);
            textBox1.Text = spisok[6 * strn + 0];
            textBox2.Text = spisok[6 * strn + 4];
            textBox3.Text = spisok[6 * strn + 1];
            textBox4.Text = spisok[6 * strn + 2];
            textBox5.Text = spisok[6 * strn + 3];
            textBox6.Text = spisok[6 * strn + 5];
            if (spisok[6 * strn + 5] != "") { pictureBox1.Visible = true; pictureBox1.Image = Image.FromFile($"{spisok[6 * strn + 5]}"); }
            else { pictureBox1.Visible = false; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            spisok.RemoveAt(6 * strn + 0);
            spisok.RemoveAt(6 * strn + 0);
            spisok.RemoveAt(6 * strn + 0);
            spisok.RemoveAt(6 * strn + 0);
            spisok.RemoveAt(6 * strn + 0);
            spisok.RemoveAt(6 * strn + 0);
            
            if (strn-1 ==max-2)
            {
                strn--;
                max--;
                label1.Text = "Вопрос № " + (strn + 1);
                textBox1.Text = spisok[6 * strn + 0];
                textBox2.Text = spisok[6 * strn + 4];
                textBox3.Text = spisok[6 * strn + 1];
                textBox4.Text = spisok[6 * strn + 2];
                textBox5.Text = spisok[6 * strn + 3];
                textBox6.Text = spisok[6 * strn + 5];
                if (spisok[6 * strn + 5] != "") { pictureBox1.Visible = true; pictureBox1.Image = Image.FromFile($"{spisok[6 * strn + 5]}"); }
                else { pictureBox1.Visible = false; }
            }
            else
                if (strn >= 0) 
            {
                max--;
                label1.Text = "Вопрос № " + (strn + 1);
                textBox1.Text = spisok[6 * strn + 0];
                textBox2.Text = spisok[6 * strn + 4];
                textBox3.Text = spisok[6 * strn + 1];
                textBox4.Text = spisok[6 * strn + 2];
                textBox5.Text = spisok[6 * strn + 3];
                if (spisok[6 * strn + 5] != "") { pictureBox1.Visible = true; pictureBox1.Image = Image.FromFile($"{spisok[6 * strn + 5]}"); }
                else { pictureBox1.Visible = false; }
            }
            label8.Text = "Из " + $"{max}";
            if (strn+1 == max) button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            strn++;
            button1.Enabled = true;
            label1.Text = "Вопрос № " + (strn + 1);
            textBox1.Text = spisok[6*strn+0];
            textBox2.Text = spisok[6 * strn + 4];
            textBox3.Text = spisok[6 * strn + 1];
            textBox4.Text = spisok[6 * strn + 2];
            textBox5.Text = spisok[6 * strn + 3];
            textBox6.Text = spisok[6 * strn + 5];
            if (spisok[6 * strn + 5] != "") { pictureBox1.Visible = true; pictureBox1.Image = Image.FromFile($"{spisok[6 * strn + 5]}");}
            else { pictureBox1.Visible = false; }
            if (strn == max-1) 
            {
                button2.Enabled = false;
                button4.Enabled = true;
            }
        } 
    }
}
