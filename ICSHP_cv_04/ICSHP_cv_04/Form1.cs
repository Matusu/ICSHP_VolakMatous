using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICSHP_cv_04
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();
            correctLabel.Text = $"Correct: {Convert.ToString(stats.Correct)}";
            missedLabel.Text = $"Missed: {Convert.ToString(stats.Missed)}";
            accuracyLabel.Text = $"Accuracy: {Convert.ToString(stats.Accuracy)}%";
            difficultyLabel.Text = "Difficulty:";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count > 6)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("G");
                listBox1.Items.Add("A");
                listBox1.Items.Add("M");
                listBox1.Items.Add("E");
                listBox1.Items.Add("O");
                listBox1.Items.Add("V");
                listBox1.Items.Add("E");
                listBox1.Items.Add("R");
                timer1.Stop();
            }
            stats.UpdatedStats += new Stats.UpdateStatusEventHandler(Staty);
        }

        private void Staty(object sender, EventArgs e)
        {
            correctLabel.Text = $"Correct: {Convert.ToString(stats.Correct)}";
            missedLabel.Text = $"Missed: {Convert.ToString(stats.Missed)}";
            accuracyLabel.Text = $"Accuracy: {Convert.ToString(stats.Accuracy)}%";
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            bool key = false;
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                key = true;
                if (timer1.Interval > 400)
                {
                    timer1.Interval -= 60;
                    diffProgBar.Value = 800 - timer1.Interval;
                }

                if (timer1.Interval > 250)
                {
                    timer1.Interval -= 15;
                    diffProgBar.Value = 800 - timer1.Interval;
                }
                try
                {
                    if (timer1.Interval > 150)
                    {
                        timer1.Interval -= 8;
                        diffProgBar.Value = 800 - timer1.Interval;
                    }

                }
                catch
                {
                    timer1.Interval = 1;
                    diffProgBar.Value = 800 - timer1.Interval;
                }
            }
            


            stats.Update(key);
        }
    }
}
