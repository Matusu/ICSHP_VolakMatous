using System;

namespace ICSHP_cv03
{
    class Program
    {
        static void Main(string[] args)
        {
            Studenti studenti = new Studenti();
            bool init = true;
            while (init)
            {
                init = Menu(studenti);
            }
        }
        public static bool Menu(Studenti studenti)
        {
            Console.Clear();
            Console.WriteLine("1 - Načtení studentů z klávesnice.\n2 - Výpis studentů.\n3 - Seřazení pode čísla.\n4 - Seřazení podle jména.\n5 - Seřazení podle fakulty.\n0 - Konec");
            switch (Console.ReadLine())
            {
                case "1":
                    studenti.Nacti();
                    return true;
                case "2":
                    studenti.Vypis();
                    Console.ReadKey();
                    return true;
                case "3":
                    studenti.SortNumber();
                    return true;
                case "4":
                    studenti.SortName();
                    return true;
                case "5":
                    studenti.SortFakult();
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
    }
}
