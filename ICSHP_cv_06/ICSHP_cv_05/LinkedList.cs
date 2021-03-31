using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_05
{
    public class LinkedList : IEnumerable, ICollection, IList
    {
        public PrvekSeznamu Prvni;
        public PrvekSeznamu Posledni;
        private int IndexWritenTo { get; set; }

        public int Count => count();

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public object this[int index] { get => getData(index); set => setData(index, value); }

        public void AddToEnd(object data)
        {
            IndexWritenTo = 0;
            if (Prvni == null)
            {
                Prvni = new PrvekSeznamu(data)
                {
                    Predchozi = null
                };
                Posledni = Prvni;
            }
            else
                Prvni.AddToEnd(data, this);
        }

        private int count()
        {
            int i = 0;
            foreach (var item in this)
            {
                i++;
            }
            return i;
        }

        private object getData(int index)
        {
            int i = 0;
            foreach (PrvekSeznamu item in this)
            {
                if (i == index)
                {
                    Hrac hrac = (Hrac)item.data;
                    return hrac;
                }
                i++;
            }
            return null;
        }

        private void setData(int index, object data)
        {
            int i = 0;
            foreach (PrvekSeznamu item in this)
            {
                if (i == index)
                    item.data = data;
            }
        }
        // implementovat
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        public int Add(object value)
        {
            AddToEnd(value);
            return IndexWritenTo;
        }

        public void Clear()
        {
            Prvni = null;
        }

        public bool Contains(object value)
        {
            foreach (PrvekSeznamu item in this)
            {
                if (value == item.data)
                    return true;
            }
            return false;
        }

        public int IndexOf(object value)
        {
            int i = 0;
            foreach (PrvekSeznamu item in this)
            {
                if (value == item.data)
                    return i;
                i++;
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            int i = 0;
            foreach (PrvekSeznamu item in this)
            {
                if(index == i)
                {
                    if(item == Prvni)
                    {
                        PrvekSeznamu temp = Prvni;
                        Prvni = new PrvekSeznamu(value);
                        Prvni.Dalsi = temp;
                        temp.Predchozi = Prvni;
                    }
                    else if(item == Posledni)
                    {
                        Posledni.Dalsi = new PrvekSeznamu(value)
                        {
                            Predchozi = Posledni
                        };
                        Posledni = Posledni.Dalsi;
                    }
                    else
                    {
                        PrvekSeznamu temp = new PrvekSeznamu(value);
                        temp.Predchozi = item.Predchozi;
                        temp.Dalsi = item;
                        item.Predchozi = temp;
                    }
                }
                i++;
            }
        }

        public void Remove(object value)
        {
            foreach (PrvekSeznamu item in this)
            {
                if (item.data == value)
                {
                    if (item == Prvni && Prvni.Dalsi != null)
                    {
                        item.Dalsi.Predchozi = null;
                        Prvni = item.Dalsi;
                    }
                    else if (item == Prvni && Prvni.Dalsi == null)
                    {
                        Prvni = null;
                    }
                    else if (item == Posledni)
                    {
                        item.Predchozi.Dalsi = null;
                        Posledni = item.Predchozi.Dalsi;
                    }
                    else
                    {
                        item.Predchozi.Dalsi = item.Dalsi;
                        item.Dalsi.Predchozi = item.Predchozi;
                    }
                }
            }
        }

        public void RemoveAt(int index)
        {
            int i = 0;
            foreach (PrvekSeznamu item in this)
            {
                if (index == i)
                {
                    if (item == Prvni && Prvni.Dalsi != null)
                    {
                        item.Dalsi.Predchozi = null;
                        Prvni = item.Dalsi;
                    }
                    else if(item == Prvni && Prvni.Dalsi == null)
                    {
                        Prvni = null;
                    }
                    else if (item == Posledni)
                    {
                        item.Predchozi.Dalsi = null;
                        Posledni = item.Predchozi.Dalsi;
                    }
                    else
                    {
                        item.Predchozi.Dalsi = item.Dalsi;
                        item.Dalsi.Predchozi = item.Predchozi;
                    }
                }
                i++;
            }
        }

        public class PrvekSeznamu
        {
            public object data { get; set; }
            public PrvekSeznamu Dalsi { get; set; }
            public PrvekSeznamu Predchozi { get; set; }

            public PrvekSeznamu(object data)
            {
                this.data = data;
                Dalsi = null;
            }

            public void AddToEnd(object data, LinkedList list)
            {
                list.IndexWritenTo++;
                if (Dalsi == null)
                {
                    Dalsi = new PrvekSeznamu(data)
                    {
                        Predchozi = this
                    };
                    list.Posledni = Dalsi;
                }
                else
                    Dalsi.AddToEnd(data, list);
            }

            public override string ToString()
            {
                return $"{data}";
            }

        }

        public class LinkedListEnumerator : IEnumerator
        {
            LinkedList list;
            PrvekSeznamu prvek;

            public LinkedListEnumerator(LinkedList list)
            {
                this.list = list;
                prvek = null;
            }


            public object Current => prvek;

            public bool MoveNext()
            {
                if (prvek == null && list.Prvni != null)
                {
                    prvek = list.Prvni;
                    return true;
                }
                else if (list.Prvni == null)
                {
                    return false;
                }
                else
                {
                    if (prvek.Dalsi != null)
                    {
                        prvek = prvek.Dalsi;
                        return true;
                    }
                    else
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
