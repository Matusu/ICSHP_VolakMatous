using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv08
{
    class MinMaxHashTable<TKey, TValue> where TKey : IComparable
    {
        TKey[] keys;
        TValue[] values;
        public TKey Minimum { get; private set; }
        public TKey Maximum { get; private set; }
        public int HashTableSize { get; private set; }
        public int Count { get; private set; } = 0;


        // default hodnotu ošetřit
        // ošetřit max min na remove

        public MinMaxHashTable()
        {
            keys = new TKey[20];
            values = new TValue[20];
            HashTableSize = 20;
        }

        public MinMaxHashTable(int pocetPrvku)
        {
            keys = new TKey[pocetPrvku];
            values = new TValue[pocetPrvku];
            HashTableSize = pocetPrvku;
        }

        public List<KeyValuePair<TKey,TValue>> this[TKey min, TKey max]
        {
            get
            {
                List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i].CompareTo(min) >= 0 && keys[i].CompareTo(max) <= 0)
                        list.Add(new KeyValuePair<TKey, TValue>(keys[i], Get(keys[i])));
                }
                return list;
            }
        }

        public List<KeyValuePair<TKey, TValue>> Range(TKey min, TKey max)
        {
            List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].CompareTo(min) >= 0 && keys[i].CompareTo(max) <= 0)
                    list.Add(new KeyValuePair<TKey, TValue>(keys[i], Get(keys[i])));
            }
            return list;
        }

        public List<KeyValuePair<TKey, TValue>> SortedRange(TKey min, TKey max)
        {
            List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].CompareTo(min) >= 0 && keys[i].CompareTo(max) <= 0)
                    list.Add(new KeyValuePair<TKey, TValue>(keys[i], Get(keys[i])));
            }
            list.Sort((pair, pair2) => { return pair.Key.CompareTo(pair2.Key); });
            return list;
        }

        public void Add(TKey key, TValue value)
        {
            int hashCode = Math.Abs(key.GetHashCode() % HashTableSize);
            if (key.CompareTo(keys[hashCode]) != 0)
            {
                keys[hashCode] = key;
                values[hashCode] = value;
                Count++;
                if (key.CompareTo(Minimum) < 0)
                    Minimum = key;
                if (key.CompareTo(Maximum) > 0)
                    Maximum = key;
            }
            else
                throw new ArgumentOutOfRangeException();

        }

        public TValue Get(TKey key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % HashTableSize);
            if (key.CompareTo(keys[hashCode]) == 0)
                return values[hashCode];
            else
                throw new KeyNotFoundException();
        }

        public bool Contains(TKey key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % HashTableSize);
            if (key.CompareTo(keys[hashCode]) == 0)
                return true;
            else
                return false;
        }

        public TValue Remove(TKey key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % HashTableSize);
            TValue valueToReturn;
            if (key.CompareTo(keys[hashCode]) == 0)
            {
                keys[hashCode] = default(TKey);
                valueToReturn = values[hashCode];
                values[hashCode] = default(TValue);
                Count--;

                return valueToReturn;
            }
            else
                throw new KeyNotFoundException();
        }

    }
}
