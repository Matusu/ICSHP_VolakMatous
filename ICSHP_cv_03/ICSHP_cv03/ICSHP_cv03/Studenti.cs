using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv03
{
    class Studenti
    {

        public Student[] studenti { get; set; }
        public Studenti()
        {
            studenti = new Student[2];
        }
        public void Vypis()
        {
            for (int i = 0; i < studenti.Length; i++)
            {
                Console.WriteLine(studenti[i]);
            }
        }
        public void Nacti()
        {
            for (int i = 0; i < studenti.Length; i++)
            {
                Student student = new Student();
                Console.WriteLine("Zadej jméno studenta: ");
                student.Jmeno = Console.ReadLine();
                Console.WriteLine("Zadej cislo studenta: ");
                if (Int32.TryParse(Console.ReadLine(), out int cislo))
                    student.Cislo = cislo;
                Console.WriteLine("Zadej fakultu studenta(0-3): ");
                if (Int32.TryParse(Console.ReadLine(), out int fakulta) && fakulta <= 3 && fakulta >= 0)
                    student.Fakulta = (FakultaEnum)fakulta;
                studenti[i] = student;
            }
        }
        public void SortNumber()
        {
            SortI(studenti, cisla);
        }
        public void SortFakult()
        {
            SortF(studenti, fakulta);
        }
        public void SortName()
        {
            SortS(studenti, jmeno);
        }

        public delegate bool PorovnejC(int a, int b);
        public delegate bool PorovnejF(FakultaEnum a, FakultaEnum b);
        public delegate bool PorovnejJ(string a, string b);
        public void SortI(Student[] studenti, PorovnejC porovnej)
        {
            for (int i = 0; i < studenti.Length; i++)
            {
                for (int j = 0; j < studenti.Length -1; j++)
                {
                    bool prohod = porovnej((int)studenti[j].Cislo, (int)studenti[j + 1].Cislo);
                    if (prohod)
                    {
                        Student temp = studenti[j];
                        studenti[j] = studenti[j + 1];
                        studenti[j + 1] = temp;
                    }   
                }
            }
        }
        public void SortF(Student[] studenti, PorovnejF porovnej)
        {
            for (int i = 0; i < studenti.Length; i++)
            {
                for (int j = 0; j < studenti.Length - 1; j++)
                {
                    bool prohod = porovnej(studenti[j].Fakulta, studenti[j + 1].Fakulta);
                    if (prohod)
                    {
                        Student temp = studenti[j];
                        studenti[j] = studenti[j + 1];
                        studenti[j + 1] = temp;
                    }
                }
            }
        }
        public void SortS(Student[] studenti, PorovnejJ porovnej)
        {
            for (int i = 0; i < studenti.Length; i++)
            {
                for (int j = 0; j < studenti.Length - 1; j++)
                {
                    bool prohod = porovnej(studenti[j].Jmeno, studenti[j + 1].Jmeno);
                    if (prohod)
                    {
                        Student temp = studenti[j];
                        studenti[j] = studenti[j + 1];
                        studenti[j + 1] = temp;
                    }
                }
            }
        }
        static bool CislaCom(int a, int b)
        {
            if (a > b)
                return true;
            else
                return false;
        }
        static bool FakultaCom(FakultaEnum a, FakultaEnum b)
        {
            if (a > b)
                return true;
            else
                return false;
        }
        static bool JmenoCom(string a, string b)
        {
            if (a[0] > b[0])
                return true;
            else
                return false;
        }
        PorovnejC cisla = CislaCom;
        PorovnejF fakulta = FakultaCom;
        PorovnejJ jmeno = JmenoCom;


    }
}
