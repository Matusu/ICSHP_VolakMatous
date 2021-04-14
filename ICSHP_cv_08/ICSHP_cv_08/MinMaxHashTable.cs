using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_08
{
    class MinMaxHashTable<TKey, TValue> where TKey : IComparable
    {
        private TKey[] Key;
        private TValue[] Value;
        private bool[] taken;
        public TKey min { get; private set; }
        public TKey max { get; private set; }

        public int Count { private set; get; } = 0;


        public MinMaxHashTable()
        {
            Key = new TKey[20];
            Value = new TValue[20];
            taken = new bool[20];
        }

        public MinMaxHashTable(int pocetPrvku)
        {
            Key = new TKey[pocetPrvku];
            Value = new TValue[pocetPrvku];
            taken = new bool[pocetPrvku];
        }

        public KeyValuePair<TKey, TValue> this[TKey min, TKey max]
        {
            get
            {
                bool containsMin = false;
                bool containsMax = false;
                for (int i = 0; i < Key.Length; i++)
                {
                    if (min.Equals(Key[i]))
                        containsMin = true;
                }
                for (int i = 0; i < Key.Length; i++)
                {
                    if (max.Equals(Key[i]))
                        containsMax = true;
                }
                if (containsMin && containsMax)
                {
                    int collectionSize = GetCount(min, max);
                    KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(collectionSize,false);
                    for (int i = 0; i < Key.Length; i++)
                    {
                        if (Key[i].CompareTo(min) >= 0 && Key[i].CompareTo(max) <= 0)
                            keyValuePair.Add(Key[i], Get(Key[i]));
                    }
                    return keyValuePair;
                }
                else
                    return null;
                
            }
        }



        private int GetCount(TKey min, TKey max)
        {
            int y = 0;
            for (int i = 0; i < Key.Length; i++)
            {
                if (Key[i].CompareTo(min) >= 0 && Key[i].CompareTo(max) <= 0)
                    y++;
            }
            return y;
        }

        private void CheckMinMax()
        {
            for (int i = 0; i < Key.Length; i++)
            {
                if (Key[i].CompareTo(default(TKey)) > 0)
                    min = Key[i];
            }
            for (int i = 0; i < Key.Length; i++)
            {
                if (Key[i].CompareTo(min) < 0 && Key[i].CompareTo(default(TKey)) > 0)
                    min = Key[i];
                if (Key[i].CompareTo(max) > 0)
                    max = Key[i];
            }
        }

        public void Add(TKey key, TValue value)
        {
            for (int i = 0; i < Key.Length; i++)
            {
                if (Equals(key, Key[i]))
                    throw new ArgumentException();
            }
            for (int i = 0; i < taken.Length; i++)
            {
                if (taken[i] == false)
                {
                    Key[i] = key;
                    Value[i] = value;
                    taken[i] = true;
                    break;
                }
            }
            CheckMinMax();
            Count++;
        }

        public bool Contains(TKey key)
        {
            bool contains = false;
            for (int i = 0; i < Key.Length; i++)
            {
                if (Equals(Key[i], key))
                {
                    contains = true;
                    return contains;
                }
            }
            return contains;
        }

        public TValue Get(TKey key)
        {
            for (int i = 0; i < Key.Length; i++)
            {
                if (Equals(Key[i], key))
                    return Value[i];
            }
            throw new KeyNotFoundException();
        }

        public TValue Remove(TKey key)
        {
            if (!this.Contains(key))
                throw new KeyNotFoundException();

            TValue value = default;
            for (int i = 0; i < Key.Length; i++)
            {
                if (Equals(Key[i], key))
                {
                    Key[i] = default;
                    value = Value[i];
                    Value[i] = default;
                    taken[i] = false;
                }
            }
            CheckMinMax();
            Count--;
            return value;
        }

        public KeyValuePair<TKey, TValue> Range(TKey min, TKey max)
        {
            bool containsMin = false;
            bool containsMax = false;
            for (int i = 0; i < Key.Length; i++)
            {
                if (min.Equals(Key[i]))
                    containsMin = true;
            }
            for (int i = 0; i < Key.Length; i++)
            {
                if (max.Equals(Key[i]))
                    containsMax = true;
            }
            if (containsMin && containsMax)
            {
                int collectionSize = GetCount(min, max);
                KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(collectionSize, false);
                for (int i = 0; i < Key.Length; i++)
                {
                    if (Key[i].CompareTo(min) >= 0 && Key[i].CompareTo(max) <= 0)
                        keyValuePair.Add(Key[i], Get(Key[i]));
                }
                return keyValuePair;
            }
            else
                return null;
            
        }

        public KeyValuePair<TKey, TValue> SortedRange(TKey min, TKey max)
        {
            bool containsMin = false;
            bool containsMax = false;
            for (int i = 0; i < Key.Length; i++)
            {
                if (min.Equals(Key[i]))
                    containsMin = true;
            }
            for (int i = 0; i < Key.Length; i++)
            {
                if (max.Equals(Key[i]))
                    containsMax = true;
            }
            if (containsMin && containsMax)
            {
                int collectionSize = GetCount(min, max);
                KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(collectionSize, true);
                for (int i = 0; i < Key.Length; i++)
                {
                    if (Key[i].CompareTo(min) >= 0 && Key[i].CompareTo(max) <= 0)
                        keyValuePair.Add(Key[i], Get(Key[i]));
                }
                return keyValuePair;
            }
            else
                return null;
        }

        public class KeyValuePair<Tkey, Tvalue> : IEnumerable where Tkey : IComparable
        {
            private Tkey[] Key;
            private Tvalue[] Value;
            private bool[] taken;
            bool sorted = false;

            public KeyValuePair(int count, bool sorted)
            {
                Key = new Tkey[count];
                Value = new Tvalue[count];
                taken = new bool[count];
                this.sorted = sorted;
            }

            public void Add(Tkey key, Tvalue value)
            {
                for (int i = 0; i < Key.Length; i++)
                {
                    if (Equals(key, Key[i]))
                        throw new ArgumentException();
                }
                for (int i = 0; i < taken.Length; i++)
                {
                    if (taken[i] == false)
                    {
                        Key[i] = key;
                        Value[i] = value;
                        taken[i] = true;
                        break;
                    }
                }
            }

            public Tvalue Get(Tkey key)
            {
                for (int i = 0; i < Key.Length; i++)
                {
                    if (Equals(Key[i], key))
                        return Value[i];
                }
                throw new KeyNotFoundException();
            }

            public IEnumerator GetEnumerator()
            {
                return new Enumerator(this, sorted);
            }

            private class Enumerator : IEnumerator
            {
                KeyValuePair<Tkey, Tvalue> keyValuePair;
                Tkey currentKey = default;
                Tvalue currentValue = default;
                bool sorted = false;
                int index = 0;

                public Enumerator(KeyValuePair<Tkey,Tvalue> keyValuePair, bool sorted)
                {
                    this.keyValuePair = keyValuePair;
                    this.sorted = sorted;
                }

                public object Current => currentValue;

                public bool MoveNext()
                {
                    if (sorted)
                    {
                        Tkey temp = default;
                        for (int i = 0; i < keyValuePair.Key.Length; i++)
                        {
                            if (currentKey.CompareTo(keyValuePair.Key[i]) > 0 && temp.CompareTo(default(Tkey)) == 0)
                                temp = keyValuePair.Key[i];
                            if(temp.CompareTo(default(Tkey)) > 0)
                            {
                                if (keyValuePair.Key[i].CompareTo(currentKey) > 0 && keyValuePair.Key[i].CompareTo(temp) < 0)
                                    temp = keyValuePair.Key[i];
                            }
                        }
                        if (temp.CompareTo(default(Tkey)) == 0)
                            return false;
                        else
                        {
                            currentKey = temp;
                            return true;
                        }

                    }
                    else
                    {
                        try
                        {
                            currentKey = keyValuePair.Key[index];
                            currentValue = keyValuePair.Get(currentKey);
                            index++;
                            return true;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            return false;
                        }
                    }
                    
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
