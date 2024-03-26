using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pract19
{
  
    public partial class Form1 : Form
    {
        
        string fio_group = "";
        string itog = "";
        List<string> spisok = new List<string>();
        int curr_numb = 0, i = 0;
        double answer = 0;
        int numb = 0;
        int vopr = 0;
        List<string[]>  questions = new List<string[]> ();
        string[] dva;
        List<int> mas = new List<int>();
        string mam = "";
        Cezar cezar = new Cezar();
        public Form1(string fio_group)
        {
            InitializeComponent();
            this.fio_group = fio_group;
            StreamReader sw = File.OpenText("voprosi.txt");
            int i = 0, j;

            while (!sw.EndOfStream)
            {
                string[] mas=new string[6];
                for (j=0;j<6;j++) 
                {
                    string st = sw.ReadLine();
                    if (st != null) { spisok.Add(cezar.Deshifr(st)); }
                    else spisok.Add("");
                    mas[j] = st;
                }
                questions.Add(mas);
                i++;
                vopr++;
            }
            sw.Close();
            this.Text= "Вопрос " + (numb+1);
            label1.Text = questions[0][ 0];
             dva = questions[curr_numb][ 4].Split('~');
            if (dva.Length > 1)
            {
                radioButton1.Visible = false; radioButton2.Visible = false; radioButton3.Visible = false;
                checkBox1.Visible = true; checkBox2.Visible = true; checkBox3.Visible = true;
                checkBox1.Text = questions[0][ 1];
                checkBox2.Text = questions[0][ 2];
                checkBox3.Text = questions[0][ 3];
            }
            else
            {
                radioButton1.Visible = true; radioButton2.Visible = true; radioButton3.Visible = true;
                checkBox1.Visible = false; checkBox2.Visible = false; checkBox3.Visible = false;
                radioButton1.Text = questions[0][ 1];
                radioButton2.Text = questions[0][ 2];
                radioButton3.Text = questions[0][ 3];
            }
            if (File.Exists($"{questions[curr_numb][ 5]}"))
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(questions[curr_numb][ 5]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dva.Length == 1)
            {
                if (radioButton1.Checked)
                {
                    if (radioButton1.Text == questions[curr_numb][ 4]) answer++; ;
                }
                else if (radioButton2.Checked)
                {
                    if (radioButton2.Text == questions[curr_numb][ 4]) answer++; ;
                }
                else if (radioButton3.Checked)
                {
                    if (radioButton3.Text == questions[curr_numb][ 4]) answer++; ;
                }
            }
            else
            {
                if (dva.Length == 2)
                {
                    if (checkBox1.Checked) { if (checkBox1.Text == dva[0] || checkBox1.Text == dva[1]) answer += 0.5; }
                    if (checkBox2.Checked) { if (checkBox2.Text == dva[0] || checkBox1.Text == dva[1]) answer += 0.5; }
                    if (checkBox3.Checked) { if (checkBox3.Text == dva[0] || checkBox1.Text == dva[1]) answer += 0.5; }
                }
                else if (dva.Length == 3)
                {
                    if (checkBox1.Checked) { if (checkBox1.Text == dva[0] || checkBox1.Text == dva[1] || checkBox1.Text == dva[2]) answer += 0.3; }
                    if (checkBox2.Checked) { if (checkBox2.Text == dva[0] || checkBox1.Text == dva[1] || checkBox2.Text == dva[2]) answer += 0.3; }
                    if (checkBox3.Checked) { if (checkBox3.Text == dva[0] || checkBox1.Text == dva[1] || checkBox2.Text == dva[2]) answer += 0.3; }
                }
                else MessageBox.Show("Выберите ответ");
            }
            if (numb +1< vopr)
            {
                numb++;
                this.Text = "Вопрос " + (numb + 1);
                Random rnd = new Random();    
                int r = rnd.Next(1, vopr);
                while (mas.Contains(r)){
                r = rnd.Next(1, vopr);
                }
                mas.Add(r);
                curr_numb = r;
                label1.Text = questions[curr_numb][ 0];
                dva = questions[curr_numb][ 4].Split('~');
                if (dva.Length > 1 )
                {
                    radioButton1.Visible = false; radioButton2.Visible = false; radioButton3.Visible = false;
                    checkBox1.Visible = true; checkBox2.Visible = true; checkBox3.Visible = true;
                    checkBox1.Text = questions[curr_numb][ 1];
                    checkBox2.Text = questions[curr_numb][ 2];
                    checkBox3.Text = questions[curr_numb][ 3];
                }
                else
                {
                    radioButton1.Visible = true; radioButton2.Visible = true; radioButton3.Visible = true;
                    checkBox1.Visible = false; checkBox2.Visible = false; checkBox3.Visible = false;
                    radioButton1.Text = questions[curr_numb][ 1];
                    radioButton2.Text = questions[curr_numb][ 2];
                    radioButton3.Text = questions[curr_numb][ 3];
                }
                if (File.Exists($"{questions[curr_numb][5]}"))
                {
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(questions[curr_numb][ 5]);
                 }
                else pictureBox1.Visible = false;
            }
            else
            {
                button1.Enabled = false;

                if (curr_numb + 1 == answer)
                {
                    itog = $" верно на все {answer} вопросов";
                    cezar.Shifr($"{itog}");
                    MessageBox.Show($"{itog}", "Результаты");
                }
                else 
                {
                   itog=$" верно {answer}  вопросов из {numb + 1} возможных ";
                    cezar.Shifr($"{itog}");
                    MessageBox.Show($"{itog}", "Резултаты");
                }
                itog = fio_group += itog;
                StreamWriter f = File.AppendText("itogi.txt");
                f.WriteLine($"{cezar.Shifr($"{itog}")}");
                f.Close();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
