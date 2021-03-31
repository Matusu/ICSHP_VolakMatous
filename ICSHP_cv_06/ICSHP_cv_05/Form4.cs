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
    public partial class Form4 : Form
    {
        public bool None;
        public bool FC_Porto;
        public bool Arsenal;
        public bool Real_Madrid;
        public bool Chelsea;
        public bool Barcelona;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            None = None_CB.Checked;
            FC_Porto = FC_Porto_CB.Checked;
            Arsenal = Arsenal_CB.Checked;
            Real_Madrid = Real_Madrid_CB.Checked;
            Chelsea = Chelsea_CB.Checked;
            Barcelona = Barcelona_CB.Checked;

            DialogResult = DialogResult.OK;
        }
    }
}
