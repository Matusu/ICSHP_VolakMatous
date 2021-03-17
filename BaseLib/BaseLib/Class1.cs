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

            class ExtraMath
            {
                public ExtraMath()
                {

                }
                /// <summary>
                /// Metoda vypočítá kořeny pro kvadratickou rovnici se zadanými koeficienty, přičemž když není řešení v oboru reálných čísel, vrátí false, když je řešení v oboru reálných čísel vrátí true
                /// </summary>
                /// <param name="a">První koeficiet kvadratické rovnice</param>
                /// <param name="b">Druhý koeficiet kvadratické rovnice</param>
                /// <param name="c">Třetí koeficiet kvadratické rovnice</param>
                /// <param name="x1">Výstupní parametr, který obsahuje hodnotu jednoho z kořenů kvadratické rovnice</param>
                /// <param name="x2">Výstupní parametr, který obsahuje hodnotu druhého z kořenů kvadratické rovnice</param>
                /// <returns>V případě, kdy rovnice má řešení v oboru reálných čísel, navrátí true, v případě, kdy rovnice nemá řešení v oboru reálných čísel, navrátí false</returns>
                public static bool Kvad(double a, double b, double c, out double x1, out double x2)
                {
                    double d = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
                    x1 = (-b + d) / 2 * a;
                    x2 = (-b - d) / 2 * a;
                    if (d < 0)
                    {
                        return false;
                    }
                    else
                        return true;
                }

                /// <summary>
                /// Metoda vrátí proměnnou typu double, která obsahuje náhodné číslo, od minimální do maximální hodnoty, které jsou vstupními parametry
                /// </summary>
                /// <param name="random">Třída typu random, sloužící pro generování náhodného čísla</param>
                /// <param name="min">Vstupní parametr představující minimální hodnotu náhodného čísla</param>
                /// <param name="max">Vstupní parametr představující maximální hodnotu náhodného čísla</param>
                /// <returns>Vrací náhodné číslo od minimální do maximální hodnoty, která je typu double</returns>
                public static double Random(Random random, int min, int max)
                {
                    return random.Next(min, max);
                }
            }

            class MathConvert
            {
                MathConvert()
                {

                }
                /// <summary>
                /// Metoda převede číslo z desítkové soustavy na dvojkovou
                /// </summary>
                /// <param name="dec">Vstupním parametrem je číslo typu int</param>
                /// <returns>Metoda vrací číslo v dvojkové soustavě uložené v poli typu int.</returns>
                public static int[] DecToBin(int dec)
                {
                    int[] bin = new int[9];
                    for (int i = 0; i < bin.Length; i++)
                    {
                        bin[i] = dec % 2;
                        dec = dec / 2;
                    }
                    return bin;
                }
                /// <summary>
                /// Metoda převede číslo z dvojkové soustavy na desítkovou
                /// </summary>
                /// <param name="bin">Vstupním parametrem je pole typu int.</param>
                /// <returns>Metoda vrací číslo v desítkové soutavě typu int</returns>
                public static int BinToDec(int[] bin)
                {
                    int dec = 0;
                    for (int i = 0; i < bin.Length; i++)
                    {
                        dec += bin[i] * (int)(Math.Pow(2, i));
                    }
                    return dec;
                }
                /// <summary>
                /// Metoda převede číslo z desítkové soustavy do římské
                /// </summary>
                /// <param name="number">Vstupním parametrem je číslo, které chceme převést</param>
                /// <returns>Metoda vrací řetězec, představující číslo převedené do římské soustavy</returns>
                public static string DecToRome(int number)
                {
                    int[] num = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
                    string[] sym = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
                    string s = "";
                    int i = 12;
                    while (number > 0)
                    {
                        int div = number / num[i];
                        number = number % num[i];
                        while (div-- > 0)
                        {
                            s += sym[i];
                        }
                        i--;
                    }
                    return s;
                }

                /// <summary>
                /// Metoda převede číslo z římské soustavy na desítkovou
                /// </summary>
                /// <param name="s">Vstupní řetězec, obsahující číslo v římské soustavě</param>
                /// <returns>Metoda vrátí číslo v desítkové soustavě typu int</returns>
                public static int RomeToDec(string s)
                {
                    int cislo = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        try
                        {
                            if (RomToDec(i, s) >= RomToDec(i + 1, s))
                                cislo += RomToDec(i, s);
                            else
                                cislo -= RomToDec(i, s);
                        }
                        catch
                        {
                            cislo += RomToDec(i, s);
                        }
                    }
                    return cislo;
                    static int RomToDec(int i, string s)
                    {
                        switch (s[i])
                        {
                            case 'I':
                                return 1;
                            case 'V':
                                return 5;
                            case 'X':
                                return 10;
                            case 'L':
                                return 50;
                            default:
                                return 0;
                        }
                    }
                }

            }
            
        }
    }
}
