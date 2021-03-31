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

        public LinkedList list = new LinkedList();

        public int Pocet { get; set; } = 0;

        public delegate void UpdateStatusEventHandler(object sender, EventArgs e);

        public event UpdateStatusEventHandler UpdatePocet;

        private void onUpdatePocet()
        {
            UpdateStatusEventHandler handler = UpdatePocet;
            if (handler != null)
                handler(this, new EventArgs());
        }

        public void Pridej(string Jmeno, int Klub, int GolPocet)
        {
            Pocet++;
            onUpdatePocet();
            //hraciPole.Resize(Pocet);
            //hraciPole[hraciPole.Length() - 1] = new Hrac()
            //{
            //    Jmeno = Jmeno,
            //    Klub = (Hrac.FotbalovyKlub)Klub,
            //    GolPocet = GolPocet
            //};

            Hrac hrac = new Hrac()
            {
                Jmeno = Jmeno,
                Klub = (Hrac.FotbalovyKlub)Klub,
                GolPocet = GolPocet
            };
            list.Add(hrac);
        }
        public void Vymaz(int index)
        {
            //for (int i = index - 1; i < hraciPole.Length(); i++)
            //{
            //    Pocet--;
            //    onUpdatePocet();
            //    if (i != hraciPole.Length() - 1)
            //    {
            //        if (hraciPole.Length() > 1)
            //            hraciPole[i] = hraciPole[i + 1];
            //        hraciPole.Resize(Pocet);
            //    }
            //    if (i == hraciPole.Length() - 1)
            //        hraciPole.Resize(Pocet);
            //}

            Pocet--;
            onUpdatePocet();
            if (list.Count > 0)
                list.RemoveAt(index - 1);
        }
        public void Uprav(string Jmeno, int Klub, int GolPocet, int index)
        {
            //hraciPole[index - 1].Jmeno = Jmeno;
            //hraciPole[index - 1].Klub = (Hrac.FotbalovyKlub)Klub;
            //hraciPole[index - 1].GolPocet = GolPocet;

            Hrac hracik = (Hrac)list[index - 1];
            hracik.Jmeno = Jmeno;
            hracik.GolPocet = GolPocet;
            hracik.Klub = (Hrac.FotbalovyKlub)Klub;
            list[index - 1] = hracik;
        }
        // string pole
        public void NjadiNejlepsiKluby(out string[] kluby, out int golPocet)
        {
            //kluby = new string[0];
            //List<string> stringList = new List<string>();
            //int max = 0;
            //int[] temp = new int[FotbalovyKlubInfo.Pocet];
            //for (int i = 0; i < hraciPole.Length(); i++)
            //{
            //    for (int j = 0; j < FotbalovyKlubInfo.Pocet; j++)
            //    {
            //        if (hraciPole[i].Klub == (Hrac.FotbalovyKlub)j)
            //            temp[j] += hraciPole[i].GolPocet;
            //    }
            //}
            //for (int i = 0; i < temp.Length; i++)
            //{
            //    if (temp[i] > max)
            //    {
            //        max = temp[i];
            //        stringList.Clear();
            //        stringList.Add(FotbalovyKlubInfo.DejNazev(i));
            //    }
            //    else if (temp[i] == max)
            //    {
            //        stringList.Add(FotbalovyKlubInfo.DejNazev(i));
            //    }

            //}
            //Array.Resize<string>(ref kluby, stringList.Count);
            //int y = 0;
            //foreach (var item in stringList)
            //{
            //    kluby[y] = item;
            //    y++;
            //}
            //golPocet = max;

            kluby = new string[0];
            List<string> stringList = new List<string>();
            int max = 0;
            int[] temp = new int[FotbalovyKlubInfo.Pocet];
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < FotbalovyKlubInfo.Pocet; j++)
                {
                    Hrac hracik = (Hrac)list[i];
                    if (hracik.Klub == (Hrac.FotbalovyKlub)j)
                        temp[j] += hracik.GolPocet;
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] > max)
                {
                    max = temp[i];
                    stringList.Clear();
                    stringList.Add(FotbalovyKlubInfo.DejNazev(i));
                }
                else if (temp[i] == max)
                {
                    stringList.Add(FotbalovyKlubInfo.DejNazev(i));
                }

            }
            Array.Resize<string>(ref kluby, stringList.Count);
            int y = 0;
            foreach (var item in stringList)
            {
                kluby[y] = item;
                y++;
            }
            golPocet = max;
        }

        public void Nacti(string filename)
        {
            FileManagement.Nacti(filename, list);
        }
        public void Uloz(bool none, bool fc_porto, bool arsenal, bool real_madri, bool chelsea, bool barcelona, string fileName)
        {
            FileManagement.Uloz(none, fc_porto, arsenal, real_madri, chelsea, barcelona, fileName, list);
        }

    }
}
