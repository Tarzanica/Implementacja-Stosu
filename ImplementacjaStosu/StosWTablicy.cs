using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stos
{
    public class StosWTablicy<T> : IStos<T>, IEnumerable<T>
    {
        private T[] tab;
        private int szczyt = -1;

        public StosWTablicy(int size = 10)
        {
            tab = new T[size];
            szczyt = -1;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : tab[szczyt];

        public int Count => szczyt + 1;

        public bool IsEmpty => szczyt == -1;

        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Clear() => szczyt = -1;

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            szczyt--;
            return tab[szczyt + 1];
        }

        public void Push(T value)
        {
            if (szczyt == tab.Length - 1)
            {
                Array.Resize(ref tab, tab.Length * 2);
            }

            szczyt++;
            tab[szczyt] = value;
            
        }

        public T[] ToArray()
        {
            //return tab;  //bardzo źle - reguły hermetyzacji

            //poprawnie:
            T[] temp = new T[szczyt + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = tab[i];
            return temp;
        }

        public void TrimExcess()
        {
            int emptyElement = 0;
            int size = tab.Length;

            foreach (var item in tab)
            {
                if (item == null)
                {
                    emptyElement++;
                }
            }

            if (emptyElement > size * 0.1)
            {
                int newSize = size - (emptyElement - (int)(size * 0.1));
                Array.Resize(ref tab, newSize);
            }            
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return new EnumeratorStosu(this);
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public IEnumerable<T> TopToBottom
        {
            get
            {
                for (int i = Count - 1; i >= 0; i--)
                {
                    yield return this[i];
                }
            }
        }

        public T this[int index]
        {
            get { return tab[index]; }
            set => tab[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //indexer   
        public System.Collections.ObjectModel.ReadOnlyCollection<T> ToArrayReadOnly()
        {
            return Array.AsReadOnly(tab);
        }



        //private class EnumeratorStosu : IEnumerator<T>
        //{
        //    private StosWTablicy<T> stos;
        //    private int position = -1;
        //    internal EnumeratorStosu(StosWTablicy<T> stos) =>
        //        this.stos = stos;
        //    public T Current => stos[position];

        //    object IEnumerator.Current => Current;

        //    public void Dispose() { }
        //    public bool MoveNext()
        //    {
        //        if (position < stos.Count - 1)
        //        {
        //            position++;
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    public void Reset() => position = -1;
        //}
    }

}
