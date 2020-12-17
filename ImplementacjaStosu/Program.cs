using ImplementacjaStosu;
using System;

namespace Stos
{
    class Program
    {
        static void Main(string[] args)
        {
            /*StosWTablicy<string> s = new StosWTablicy<string>(2);
            s.Push("km");
            s.Push("aa");
            s.Push("xx");
            foreach (var x in s.ToArray())
                Console.WriteLine(x);

            Console.WriteLine();

            IStos<char> stos = new StosWTablicy<char>();

            foreach (var x in ((StosWTablicy<char>)stos).TopToBottom)
            {
                Console.WriteLine(x);
            }

            for (int i = 0; i < s.Count; i++)
                Console.WriteLine(s[i]);

            Console.WriteLine("------------------");

            Console.WriteLine("Count of elements in the Stack = " + s.Count);
            s.Clear();
            s.TrimExcess();
            Console.WriteLine("Count of elements in the Stack (updated) = " + s.Count);

            Console.WriteLine("--------- Linked List ---------");

            StosWLiscie<string> l = new StosWLiscie<string>();
            l.Push("km");
            l.Push("aa");
            l.Push("xx");

            foreach (var x in l)
            {
                Console.WriteLine(x);
            }*/
            var stos = new StosWLiscie<char>();
            char e = 'a';

            Console.WriteLine(stos.IsEmpty);
            stos.Push(e);
            Console.WriteLine(e + " == " + stos.Peek);
        }
    }
}