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
    public partial class Form3 : Form
    {
        public Form3(int goly, string[] kluby)
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(goly);
            for (int i = 0; i < kluby.Length; i++)
            {
                listBox1.Items.Add(kluby[i]);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
    }
}
