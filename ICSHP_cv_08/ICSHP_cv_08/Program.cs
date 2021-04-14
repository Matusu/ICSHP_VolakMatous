using System;

namespace ICSHP_cv_08
{
    class Program
    {
        static void Main(string[] args)
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>(10);
            for (int i = 1; i < 11; i++)
            {
                table.Add(i, "string" + i);
            }
            var key = table[1, 6];
            foreach (var item in key)
            {
                Console.WriteLine(item);
            }

        }
    }
}
