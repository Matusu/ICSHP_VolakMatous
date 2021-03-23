using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICSHP_cv_05
{
    class Hraci
    {
        public class Colection
        {
            public Hrac[] hraciPole = new Hrac[0];
            public Hrac this[int i]
            {
                get { return hraciPole[i]; }
                set { hraciPole[i] = value; }
            }
            public int Length()
            {
                return hraciPole.Length;
            }
            public void Resize(int pocet)
            {
                Array.Resize<Hrac>(ref hraciPole, pocet);
            }

        }
        public Colection hraciPole = new Colection();

        public int Pocet { get; set; } = 0;

        public delegate void UpdateStatusEventHandler(object sender, EventArgs e);

        public event UpdateStatusEventHandler UpdatePocet;

        private void onUpdatePocet()
        {
            UpdateStatusEventHandler handler = UpdatePocet;
            if (handler != null)
                handler(this, new EventArgs());
        }

        public void Prijde(string Jmeno, int Klub, int GolPocet)
        {
            Pocet++;
            onUpdatePocet();
            hraciPole.Resize(Pocet);
            hraciPole[hraciPole.Length() - 1] = new Hrac()
            {
                Jmeno = Jmeno,
                Klub = (Hrac.FotbalovyKlub)Klub,
                GolPocet = GolPocet
            };
        }
        public void Vymaz(int index)
        {
            for (int i = index - 1; i < hraciPole.Length(); i++)
            {
                Pocet--;
                onUpdatePocet();
                if (hraciPole.Length() > 1)
                    hraciPole[i] = hraciPole[i + 1];
                hraciPole.Resize(Pocet);
            }
        }
        public void Uprav(string Jmeno, int Klub, int GolPocet, int index)
        {
            hraciPole[index - 1].Jmeno = Jmeno;
            hraciPole[index - 1].Klub = (Hrac.FotbalovyKlub)Klub;
            hraciPole[index - 1].GolPocet = GolPocet;
        }
        // string pole
        public void NjadiNejlepsiKluby(out string[] kluby, out int golPocet)
        {
            kluby = new string[0];
            List<string> list = new List<string>();
            int max = 0;
            int[] temp = new int[FotbalovyKlubInfo.Pocet];
            for (int i = 0; i < hraciPole.Length(); i++)
            {
                for (int j = 0; j < FotbalovyKlubInfo.Pocet; j++)
                {
                    if (hraciPole[i].Klub == (Hrac.FotbalovyKlub)j)
                        temp[j] += hraciPole[i].GolPocet;
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] > max)
                {
                    max = temp[i];
                    list.Clear();
                    list.Add(FotbalovyKlubInfo.DejNazev(i));
                }
                else if (temp[i] == max)
                {
                    list.Add(FotbalovyKlubInfo.DejNazev(i));
                }

            }
            Array.Resize<string>(ref kluby, list.Count);
            int y = 0;
            foreach (var item in list)
            {
                kluby[y] = item;
                y++;
            }
            golPocet = max;

        }

    }
}
