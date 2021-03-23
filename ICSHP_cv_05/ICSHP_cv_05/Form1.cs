using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICSHP_cv_05
{

    public partial class Form1 : Form
    {
        string jmeno;
        int klub;
        int gol;
        Hraci hraci = new Hraci();
        public ListBox list = new ListBox();

        public Form1()
        {
            InitializeComponent();

        }

        private void Print(object sender, EventArgs e)
        {
            listBox2.Items.Add(hraci.Pocet);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();

            form.ShowDialog();
            if ((int)form.DialogResult == 1)
            {
                hraci.Prijde(form.Jmeno, form.Klub, form.Gol);
                Vypis();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (Int32.TryParse(textBox1.Text, out int cislo) &&
            //   cislo > 0 &&
            //   cislo <= listBox1.Items.Count)
                hraci.Vymaz(listBox1.SelectedIndex +1);
            Vypis();
        }

        private void Vypis()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < hraci.hraciPole.Length(); i++)
            {
                listBox1.Items.Add(hraci.hraciPole[i]);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int goly;
            string[] kluby;
            hraci.NjadiNejlepsiKluby(out kluby, out goly);
            Form3 form = new Form3(goly, kluby);
            form.ShowDialog();
        }

        private void UpravitButton_Click(object sender, EventArgs e)
        {
                Form2 form = new Form2();
                form.ShowDialog();
                if ((int)form.DialogResult == 1)
                {
                    hraci.Uprav(form.Jmeno, form.Klub, form.Gol, listBox1.SelectedIndex + 1);
                    Vypis();
                }

        }

        private void RegistrovatButton_Click(object sender, EventArgs e)
        {
            hraci.UpdatePocet += new Hraci.UpdateStatusEventHandler(Print);
        }

        private void ZrušitRegistraciButton_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            hraci.UpdatePocet -= new Hraci.UpdateStatusEventHandler(Print);
        }


        private void UkoncitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
