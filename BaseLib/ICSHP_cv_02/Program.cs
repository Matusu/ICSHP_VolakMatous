using System;

namespace ICSHP_cv_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pole;
            pole = new int[3];
            bool init = true;
            while (init)
            {
                init = Menu(pole);
            }

        }

        public static bool Menu(int[] pole)
        {
            Console.Clear();
            Console.WriteLine("1 - Volba velikosti pole, následné naplnění.\n2 - Výpis pole.\n3 - Vzestupné utřídění pole.\n4 - Sestupné utřídění pole.\n5 - Hledání prvního výskytu zadaného čísla.\n6 - Hledání posledního výskytu zadaného čísla.\n7 - konec programu.");
            switch (Console.ReadLine())
            {
                case "1":
                    FillArray(pole);
                    return true;
                case "2":
                    PrintArray(pole);
                    return true;
                case "3":
                    SortAcs(pole);
                    return true;
                case "4":
                    SortDesc(pole);
                    return true;
                case "5":
                    First(pole);
                    return true;
                case "6":
                    Last(pole);
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }
        }

        public static void SortDesc(int[] pole)
        {
            for (int i = 0; i < pole.Length; i++)
            {
                for (int j = i + 1; j < pole.Length; j++)
                {
                    if (pole[i] < pole[j])
                    {
                        int temp = pole[i];
                        pole[i] = pole[j];
                        pole[j] = temp;
                    }
                }
            }
        }

        public static void SortAcs(int[] pole)
        {
            for (int i = 0; i < pole.Length; i++)
            {
                for (int j = i + 1; j < pole.Length; j++)
                {
                    if (pole[i] > pole[j])
                    {
                        int temp = pole[i];
                        pole[i] = pole[j];
                        pole[j] = temp;
                    }
                }
            }
        }

        public static void Min(int[] pole)
        {
            int min = pole[0];
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i] < min)
                    min = pole[i];
            }
            Console.WriteLine($"Nejmenší prvek: {min}");
        }

        public static void First(int[] pole)
        {
            Console.WriteLine("Zadej hledané číslo");
            int iprvni;
            int tady = -1;
            string sprvni = Console.ReadLine();
            while (!(Int32.TryParse(sprvni, out iprvni)))
            {
                Console.WriteLine("špatný vstup, zadej znova: ");
                sprvni = Console.ReadLine();
            }
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i] != iprvni)
                    continue;
                if (tady == -1)
                    tady = i;
            }
            if (tady == -1)
                Console.WriteLine("Nenalezeno");
            else
                Console.WriteLine($"první výskyt zadaného čísla je na pozici: {tady + 1}");
            Console.WriteLine("Pro návrat do menu, stiskni libovolnou klávesu");
            Console.ReadKey();
        }
        public static void Last(int[] pole)
        {
            Console.WriteLine("Zadej hledané číslo: ");
            int iposledni = 0;
            int tu = -1;
            string sposledni = Console.ReadLine();
            while (!(Int32.TryParse(sposledni, out iposledni)))
            {
                Console.WriteLine("špatný vstup, zadej znova: ");
                sposledni = Console.ReadLine();
            }
            for (int i = pole.Length - 1; i >= 0; i--)
                {
                    if (pole[i] == iposledni && tu == -1)
                        tu = i;

                }
                if (tu == -1)
                    Console.WriteLine("Nenalezeno");
                else
                    Console.WriteLine($"Poslední výskyt čísla je na pozici {tu + 1}");
            Console.WriteLine("Pro návrat do menu, stiskni libovolnou klávesu");
            Console.ReadKey();
        }

        public static void FillArray(int[] pole)
        {

            for (int i = 0; i < pole.Length; i++)
            {
                pole[i] = Fei.BaseLib.Reading.ReadInt($"Zadej {i + 1}. věk: ");
            }
        }

        public static void PrintArray(int[] pole)
        {
            Console.WriteLine("Obsah pole:");
            for (int i = 0; i < pole.Length; i++)
            {
                
                Console.WriteLine($"\n{pole[i]}");
            }
            Console.WriteLine("Pro návrat do menu, stiskni libovolnou klávesu");
            Console.ReadKey();
        }

        public static void Resize(int[] pole)
        {
            Console.WriteLine("Zadej velikost pole");
            string length = Console.ReadLine();
            int velikost;
            while (!(Int32.TryParse(length, out velikost)))
            {
                Console.WriteLine("špatný vstup, zadej znova: ");
                length = Console.ReadLine();
            }
            Array.Resize(ref pole, velikost);
        }
    }
}
