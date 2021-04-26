using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv08
{
    class LinkedList<T> : IEnumerable<T> where T : IComparable
    {
        public Prvek prvni;
        public Prvek posledni;
        public int Count { get; set; } = 0;

        public LinkedList()
        {
            prvni = null;
            posledni = null;
        }

        public void Remove(T data)
        {
            IEnumerator enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Prvek item = enumerator.Current as Prvek;
                if (item.data.CompareTo(data) == 0)
                {
                    if (item == prvni && prvni.dalsi != null)
                    {
                        item.dalsi.predchozi = null;
                        prvni = item.dalsi;
                        Count--;
                    }
                    else if(item == prvni && prvni.dalsi == null)
                    {
                        prvni = null;
                    }
                    else if (item == posledni)
                    {
                        item.predchozi.dalsi = null;
                        posledni = item.predchozi;
                        Count--;
                    }
                    else
                    {
                        item.predchozi.dalsi = item.dalsi;
                        item.dalsi.predchozi = item.predchozi;
                        Count--;
                    }

                }
            }
        }

        public void Add(T data)
        {
            if (prvni == null)
            {
                prvni = new Prvek(data)
                {
                    predchozi = null
                };
                posledni = prvni;
                Count++;
            }
            else
                prvni.Add(data, this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public class Prvek
        {
            public T data;
            public Prvek dalsi;
            public Prvek predchozi;

            public Prvek(T data)
            {
                this.data = data;
                dalsi = null;
            }

            public void Add(T data, LinkedList<T> list)
            {
                if (dalsi == null)
                {
                    dalsi = new Prvek(data)
                    {
                        predchozi = this
                    };
                    list.posledni = dalsi;
                    list.Count++;
                }
                else
                    dalsi.Add(data, list);
            }

            public override string ToString()
            {
                return $"{data}";
            }
        }

        private class Enumerator : IEnumerator<T>
        {
            LinkedList<T> list;
            public Prvek prvek{ get; private set; }

            public Enumerator(LinkedList<T> list)
            {
                this.list = list;
                prvek = null;
            }

            public T Current => prvek.data;

            object IEnumerator.Current => prvek;

            public bool MoveNext()
            {
                if (prvek == null && list.prvni != null)
                {
                    prvek = list.prvni;
                    return true;
                }
                else if (list.prvni == null)
                    return false;
                else
                {
                    if (prvek.dalsi != null)
                    {
                        prvek = prvek.dalsi;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public void Dispose()
            {
            }

            public void Reset()
            {
            }
        }

    }
}
