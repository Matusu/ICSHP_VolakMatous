using System;
using System.Collections.Generic;

namespace ICSHP_cv08
{
    class Program
    {
        static void Main(string[] args)
        {
            MinMaxHashTable<int, string> hashTable = new MinMaxHashTable<int, string>(10);
            hashTable.Add(3, "string3");
            hashTable.Add(1, "string1");
            hashTable.Add(5, "string5");

            var sortedCollection = hashTable[1, 10];
            foreach (var item in sortedCollection)
            {
                Console.WriteLine(item.Key);
            }

        }
    }
}
