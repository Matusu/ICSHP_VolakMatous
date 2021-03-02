using System;

namespace Fei
{
    namespace BaseLib
    {
        public class Reading
        {
            /// <summary>
            /// Opakovaně čte vstup z konzole dokuď není zadán vstup, který lze převést na double
            /// </summary>
            /// <param name="number">Proměnná, do které se uloží převedený vstup z konzole</param>
            /// <param name="msg">Zpráva vypsaná v konzoli, před požadavkem zadání vstupu</param>
            /// <returns>Vrací číslo datového typu double</returns>
            public static double ReadDouble(out double number, string msg)
            {
                Console.WriteLine($"{msg}: ");
                string str = Console.ReadLine();
                while (!(double.TryParse(str, out number)))
                {
                    Console.WriteLine("špatný vstup, zadej znova: ");
                    str = Console.ReadLine();
                }
                return number;
            }
            /// <summary>
            /// Vrátí první znak zadaného vstupu do konzole
            /// </summary>
            /// <param name="c">Proměnná, do které se uloží znak</param>
            /// <param name="msg">Zpráva vypsaná v konzoli, před požadavkem zadání vstupu</param>
            /// <returns>Vrátí první znak řetězce, zadaného jako vstup do konzole</returns>
            public static char ReadChar(out char c, string msg)
            {
                Console.WriteLine($"{msg}: ");
                string str = Console.ReadLine();
                c = str[0];
                return c;
            }
            /// <summary>
            /// Vrátí řetězec zadaný jako vstup do konzole
            /// </summary>
            /// <param name="str">Proměnná, do které se uloží řetězec, zadaný jako vstup do konzole</param>
            /// <param name="msg">Zpráva vypsaná v konzoli, před požadavkem zadání vstupu</param>
            /// <returns>Vrátí řetězec zadaný jako vstup do konzole</returns>
            public static string ReadString(out string str, string msg)
            {
                Console.WriteLine($"{msg}: ");
                str = Console.ReadLine();
                return str;
            }
            /// <summary>
            /// Opakovaně čte vstup z konzole dokuď není zadán vstup, který lze převést na int
            /// </summary>
            /// <param name="msg">Zpráva vypsaná v konzoli, před požadavkem zadání vstupu</param>
            /// <returns>Vrátí číslo datového typu int</returns>
            public static int ReadInt(string msg)
            {
                string str;
                int cislo;
                Console.WriteLine($"{msg}: ");
                str = Console.ReadLine();
                while (!(Int32.TryParse(str, out cislo)))
                {
                    Console.WriteLine("špatný vstup, zadej znova: ");
                    str = Console.ReadLine();
                }
                return cislo;
            }
        }
    }
}
