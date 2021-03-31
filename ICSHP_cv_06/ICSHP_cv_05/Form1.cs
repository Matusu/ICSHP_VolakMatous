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
        readonly Hraci hraci = new Hraci();

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

        private void Pridej_button(object sender, EventArgs e)
        {
            Form2 form = new Form2(hraci.list, false, 0);

            form.ShowDialog();
            if ((int)form.DialogResult == 1)
            {
                hraci.Pridej(form.Jmeno, form.Klub, form.Gol);
                Vypis();
            }

        }

        private void Vymaz_button(object sender, EventArgs e)
        {
            //try
            //{
            //    if (hraci.hraciPole.Length() > 0)
            //        hraci.Vymaz(listBox1.SelectedIndex + 1);
            //    Vypis();
            //}
            //catch
            //{
            //    listBox1.Items.Add(listBox1.SelectedIndex + 1);
            //}
            if (hraci.list.Count > 0)
                hraci.Vymaz(listBox1.SelectedIndex + 1);
            Vypis();
        }

        private void Vypis()
        {
            //listBox1.Items.Clear();
            //if (hraci.hraciPole.Length() > 0)
            //{
            //    for (int i = 0; i < hraci.hraciPole.Length(); i++)
            //    {
            //        listBox1.Items.Add(hraci.hraciPole[i]);
            //    }
            //}
            listBox1.Items.Clear();
            foreach (LinkedList.PrvekSeznamu item in hraci.list)
            {
                listBox1.Items.Add(item);
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
            Form2 form = new Form2(hraci.list, true, listBox1.SelectedIndex);
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

        private void NactiButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                hraci.Nacti(ofd.FileName);
                Vypis();
            }
        }

        private void Uloz_Button_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            OpenFileDialog ofd = new OpenFileDialog();
            form.ShowDialog();
            if ((int)form.DialogResult == 1)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    hraci.Uloz(form.None, form.FC_Porto, form.Arsenal, form.Real_Madrid, form.Chelsea, form.Barcelona, ofd.FileName);
            }

        }
    }
}
