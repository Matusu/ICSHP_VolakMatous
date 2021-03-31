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
    public partial class Form2 : Form
    {
        public string Jmeno;
        public int Gol;
        public int Klub;
        private bool upravit;
        private int index;
        private readonly LinkedList list;
        public Form2(LinkedList list, bool upravit, int index)
        {
            InitializeComponent();
            this.upravit = upravit;
            this.list = list;
            this.index = index;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < FotbalovyKlubInfo.Pocet; i++)
            {
                KlubComboBox.Items.Add(FotbalovyKlubInfo.DejNazev(i));
            }
            if(upravit)
            {
                Hrac hracik = (Hrac)list[index];
                JmenoTextBox.Text = hracik.Jmeno;
                GolTextBox.Text = Convert.ToString(hracik.GolPocet);
                KlubComboBox.SelectedText = FotbalovyKlubInfo.GetName((FotbalovyKlubInfo.FotbalovyKlub)hracik.Klub);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
            Jmeno = JmenoTextBox.Text;
            Klub = (int)KlubComboBox.SelectedIndex;
            if (!(Int32.TryParse(GolTextBox.Text, out Gol)))
                GolTextBox.Text = "Zadej číslo";
            else
                DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
