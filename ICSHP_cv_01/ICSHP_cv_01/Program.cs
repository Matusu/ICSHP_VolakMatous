using System;

namespace ICSHP_cv_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Př. 1
            Console.WriteLine("Josef Novák\nJindřišská 16\n111 50, Praha 1");
            Console.ReadKey();

            // Př. 2
            for (char pismeno = 'a'; pismeno <= 'z'; pismeno++)
            {
                Console.Write($"{pismeno} \n");
            }
            Console.ReadKey();

            char abc = 'a';
            while (abc <= 'z')
            {
                Console.Write($"{abc} \n");
                abc++;
            }
            Console.ReadKey();

            char az = 'a';
            do
            {
                Console.Write($"{az} \n");
                az++;
            }
            while (az <= 'z');
            Console.ReadKey();

            // Př. 3
            string rodne = "161031/4113";
            ulong rodnec = 1610314113;
            RodneCislo(rodne, rodnec);

            // Př. 4
            string s;
            do
            {
                Random r = new Random();
                int rnd = r.Next(101);
                int pokus = 0;
                int cislo = 0;
                do
                {
                    Console.WriteLine("hádej");
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out cislo))
                    {
                        if (cislo < rnd)
                            Console.WriteLine("Číslo je menší");

                        if (cislo > rnd)
                            Console.WriteLine("Číslo je větší");
                    }
                    pokus++;
                } while (cislo != rnd);
                Console.WriteLine($"uhádl jsi na {pokus}. pokus");
                Console.WriteLine("zadej 'y' pro hádání znova \nzadej 'n' pro ukončení programu");
                int ano = 0;
                do
                {
                    s = Console.ReadLine();
                    if (s == "y")
                        ano = 1;
                    else if (s == "n")
                        ano = 1;
                    else
                        ano = 0;
                } while (ano == 0);
                
            } while (s != "n");
            Console.WriteLine("program ukončen");
        }

        public static void RodneCislo(string rodcislo, ulong rodnecislo) 
        {
            char c = rodcislo[2];
            int cislo = (int)Char.GetNumericValue(c);
            if (cislo > 3)
                Console.WriteLine("Rodné číslo ženy");
            else
                Console.WriteLine("Rodné číslo muže");

            ulong zbyt = rodnecislo % 100000000;
            if (zbyt >30000000)
                Console.WriteLine("Rodné číslo ženy");
            else
                Console.WriteLine("Rodné číslo muže");
            Console.ReadKey();
        }

    }
}
