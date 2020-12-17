using Stos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ImplementacjaStosu
{
    public class StosWLiscie<T> : IStos<T>, IEnumerable<T>
    {
        public class Node<T>
        {
            private T data;
            public T Data { get {return data;} }

            Node<T> prev;
            public Node<T> Prev { get { return prev; } set { prev = value; } }

            Node<T> next;
            public Node<T> Next { get { return next; } set { next = value; } }

            public Node(T data)
            {
                this.data = data;
            }

            public bool hasNext()
            {
                return this.next != null;
            }

            public bool hasPrev()
            {
                return this.prev != null;
            }
        }

        private Node<T> first;
        private Node<T> last;

        private int count;
        public int Count => count;

        public StosWLiscie()
        {
            first = last =  null;
            count = 0;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : last.Data;

        public T Pop()
        {
            if (IsEmpty) throw new StosEmptyException();
            Node<T> popNode = last;
            if (count == 1) first = last = null;
            if (last.Prev == first) last = first;
            else
            {
                var node = last.Prev;
                node.Next = null;
                last = node;
            }
            count--;
            return popNode.Data;
        }

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value);
            if (IsEmpty) first = node;
            else
            {
                last.Next = node;
                node.Prev = last;
            }
            last = node;
            count++;
        }

        //public T[] ToArray<T>()
        //{
        //    T[] temp = new T[count];
        //    int index = 0;
        //    var node = first;
        //    while (node != null)
        //    {
        //        temp[index] = node;
        //        node = node.Next;
        //    }

        //    return temp;
        //}

        public Node<T>[] ToArray()
        {
            // You´ve got pre-computed count - let´s use it
            Node<T>[] result = new Node<T>[count];

            Node<T> node = first;

            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = node;
                node = node.Next;
            }

            return result;
        }

        public void TrimExcess() => throw new NotImplementedException();

        public bool IsEmpty => Count == 0;

        T IEnumerator<T>.Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public T this[int index] => readPosition(index);

        private T readPosition(int index)
        {
            Node<T> current = first;
            int position = 0;
            while (current.hasNext())
            {
                if (position == index) return current.Data;
                position++;
                current = current.Next;
            }
            if (position == index) return current.Data;
            throw new IndexOutOfRangeException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = first;
            while (node.hasNext())
            {
                yield return node.Data;
                node = node.Next;
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
