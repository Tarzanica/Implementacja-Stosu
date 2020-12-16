using Stos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ImplementacjaStosu
{
    public class StosWLiscie<T> : IStos<T>, IEnumerable<T>
    {
        private class Node<T>
        {
            private T data;
            public T Data { get; }
            Node<T> prev;
            public Node<T> Prev { get; set; }
            Node<T> next;
            public Node<T> Next { get; set; }

            public Node(T data)
            {
                this.data = data;
            }

            public Node(T data, Node<T> next)
            {
                this.data = data;
                this.next = next;
            }
        }

        private Node<T> first;
        private Node<T> last;

        private int count = 0;
        public int Count => count;

        public StosWLiscie()
        {
            first = last =  null;
            count = 0;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : last.Data;

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            var data = last.Data;
            last = last.Next;
            count--;

            return data;
        }

        public void Push(T value)
        {
            if (IsEmpty)
            {
                last = new Node<T>(value);
                count++;
            }
            else
            {
                last = new Node<T>(value, last);
                count++;
            }           
        }

        //public T[] ToArray<T>()
        //{
            
        //}

        public void TrimExcess()
        {
            int emptyElement = 0;
            int size = count;

        }       
        
        public bool IsEmpty => Count == 0;

        T IEnumerator<T>.Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public T this[int index]
        {
            get { return Get(index); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = first;
            while (node != null)
            {
                yield return node.Data;
                node = node.Prev;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private T Get(int index)
        {
            Node<T> current;
            if (index < 0)
                throw new ArgumentOutOfRangeException();

            if (index >= Count)
                index = Count - 1;

            if (index < Count)
            {
                current = first;

                for (int i = 0; i < index; i++)
                    current = current.Next;
            }
            else
            {
                current = last;
                for (int i = 0; i > index; i--)
                {
                    current = current.Prev;
                }
            }
                
            return current.Data;
        }

        void IStos<T>.Clear()
        {
            throw new NotImplementedException();
        }

        T[] IStos<T>.ToArray()
        {
            throw new NotImplementedException();
        }

        bool IEnumerator.MoveNext()
        {
            throw new NotImplementedException();
        }

        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
