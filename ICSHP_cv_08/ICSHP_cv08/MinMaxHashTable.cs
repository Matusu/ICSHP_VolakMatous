using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv08
{
    class MinMaxHashTable<TKey, TValue> where TKey : IComparable where TValue : IComparable
    {
        LinkedList<TKey>[] keys;
        LinkedList<TValue>[] values;
        public TKey Minimum { get; private set; }
        public TKey Maximum { get; private set; }
        public int HashTableSize { get; private set; }
        public int Count { get; private set; } = 0;

        // ošetřit max min na remove

        public MinMaxHashTable()
        {
            keys = new LinkedList<TKey>[20];
            values = new LinkedList<TValue>[20];
            HashTableSize = 20;
        }

        public MinMaxHashTable(int pocetPrvku)
        {
            keys = new LinkedList<TKey>[pocetPrvku];
            values = new LinkedList<TValue>[pocetPrvku];
            HashTableSize = pocetPrvku;
        }

        public List<KeyValuePair<TKey, TValue>> this[TKey min, TKey max]
        {
            get
            {
                List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
                foreach (var collection in keys)
                {
                    if(collection != null)
                    {
                        foreach (var item in collection)
                        {
                            if (item.CompareTo(min) >= 0 && item.CompareTo(max) <= 0)
                                list.Add(new KeyValuePair<TKey, TValue>(item, Get(item)));
                        }
                    }
                }
                return list;
            }
        }

        public List<KeyValuePair<TKey, TValue>> Range(TKey min, TKey max)
        {
            List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
            foreach (var collection in keys)
            {
                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        if (item.CompareTo(min) >= 0 && item.CompareTo(max) <= 0)
                            list.Add(new KeyValuePair<TKey, TValue>(item, Get(item)));
                    }
                }
            }
            return list;
        }

        public List<KeyValuePair<TKey, TValue>> SortedRange(TKey min, TKey max)
        {
            List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
            foreach (var collection in keys)
            {
                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        if (item.CompareTo(min) >= 0 && item.CompareTo(max) <= 0)
                            list.Add(new KeyValuePair<TKey, TValue>(item, Get(item)));
                    }
                }
            }
            list.Sort((pair, pair2) => { return pair.Key.CompareTo(pair2.Key); });
            return list;
        }

        // stejnej klíč ošetřit
        public void Add(TKey key, TValue value)
        {
            int hashCode = Math.Abs(key.GetHashCode() % HashTableSize);
            if (keys[hashCode] == null)
            {
                keys[hashCode] = new LinkedList<TKey>();
                values[hashCode] = new LinkedList<TValue>();
            }
            if (!Contains(key))
            {
                keys[hashCode].Add(key);
                values[hashCode].Add(value);
                MaxMin();
                Count++;
            }
            else
                throw new ArgumentException();
        }

        public TValue Get(TKey key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % HashTableSize);
            if (keys[hashCode] != null)
            {
                if (keys[hashCode].prvni != null)
                    return GetValue(GetIndex(key, hashCode), hashCode);
                else
                    throw new KeyNotFoundException();
            }
            else
                throw new KeyNotFoundException();
        }

        private int GetIndex(TKey key, int hashCode)
        {
            int i = 0;
            foreach (TKey item in keys[hashCode])
            {
                if (item.CompareTo(key) == 0)
                    return i;
                else
                    i++;
            }
            return i;
        }

        private TValue GetValue(int index, int hashCode)
        {
            int y = 0;
            foreach (TValue item in values[hashCode])
            {
                if (index == y)
                    return item;
                else
                    y++;
            }
            return default;
        }

        public bool Contains(TKey key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % HashTableSize);
            bool contains = false;
            if (keys[hashCode] != null)
            {
                if (keys[hashCode].prvni != null)
                {
                    foreach (var item in keys[hashCode])
                    {
                        if (item.CompareTo(key) == 0)
                        {
                            contains = true;
                            break;
                        }
                        else
                            contains = false;
                    }
                    return contains;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public TValue Remove(TKey key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % HashTableSize);
            TValue valueToReturn;
            if (Contains(key))
            {
                valueToReturn = GetValue(GetIndex(key, hashCode), hashCode);
                keys[hashCode].Remove(key);
                values[hashCode].Remove(valueToReturn);
                MaxMin();
                Count--;
                return valueToReturn;
            }
            else
                throw new KeyNotFoundException();
        }

        private void MaxMin()
        {
            foreach (var collection in keys)
            {
                if(collection != null)
                {
                    Maximum = collection.prvni.data;
                    Minimum = collection.prvni.data;
                    break;
                }
            }

            foreach (var collection in keys)
            {
                if(collection != null)
                {
                    foreach (var item in collection)
                    {
                        if (item.CompareTo(Minimum) < 0)
                            Minimum = item;
                        if (item.CompareTo(Maximum) > 0)
                            Maximum = item;
                    }
                }
            }
        }

    }
}
