using System;
using System.Collections.Generic;

namespace ICSHP_cv08
{
    class Program
    {
        static void Main(string[] args)
        {
            MinMaxHashTable<int, string> hashTable = new MinMaxHashTable<int, string>(10);
            hashTable.Add(16, "string16");
            hashTable.Add(16, "string6");
            

        }
    }
}
