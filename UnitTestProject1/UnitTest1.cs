using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stos;
using ImplementacjaStosu;
using System;

namespace UnitTestProjectStos
{
    [TestClass]
    public class UnitTestStosChar
    {
        private IStos<char> stos;
        private Random rnd = new Random();
        //zwraca znak ASCII o kodzie z zakresu 33..126
        private char RandomElement => (char)rnd.Next(33, 126);

        // s.create ==> s.IsEmpty==true
        [TestMethod]
        public void IsEmpty_PoUtworzeniuStosJestPusty()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);
        }

        // s.create.Push(e) ==> s.IsEmpty==false
        [TestMethod]
        public void IsEmpty_PoUtworzeniuIDodaniuElementuStosNieJestPusty()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            Assert.IsFalse(stos.IsEmpty);
        }

        // s.Pop( s.Push(e) ) == s
        [TestMethod]
        public void PushPop_StosSieNieZmienia()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            char[] tabPrzed = stos.ToArray();
            char e = RandomElement;
            stos.Push(e);
            stos.Pop();
            char[] tabPo = stos.ToArray();

            CollectionAssert.AreEqual(tabPrzed, tabPo);
        }

        // s.Peek( s.Push(e) ) == e
        [TestMethod]
        public void Peek_ZwracaOstatnioWstawionyElement()
        {
            stos = new StosWTablicy<char>();
            char e = RandomElement;

            stos.Push(e);

            Assert.AreEqual(stos.Peek, e);
        }

        // s.create.Peek ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PeekDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        // s.create.Pop() ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PopDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        // TrimExcess
        [TestMethod]
        public void TrimExcess()
        {
            stos = new StosWTablicy<char>();

            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            stos.Clear();
            stos.TrimExcess();

            Assert.AreEqual(0, stos.Count);
        }

        // indexer
        [TestMethod]
        public void Indexer()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            for (int i = 0; i < stos.Count; i++)
            {
                Console.WriteLine(stos[i]);
            }
        }
    }

    [TestClass]

    public class StackInLinkedList_UnitTests
    {
        private IStos<char> stos;
        private Random rnd = new Random();
        private char RandomElement => (char)rnd.Next(33, 126);

        [TestMethod]
        public void IsEmpty_PoUtworzeniuStosJestPusty()
        {
            stos = new StosWLiscie<char>();
            Assert.IsTrue(stos.IsEmpty);
        }

        [TestMethod]
        public void IsEmpty_PoUtworzeniuIDodaniuElementuStosNieJestPusty()
        {
            stos = new StosWLiscie<char>();
            stos.Push(RandomElement);
            Assert.IsFalse(stos.IsEmpty);
        }

        [TestMethod]
        public void PushPop_StosSieNieZmienia()
        {
            stos = new StosWLiscie<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            //char[] tabPrzed = stos.ToArray();
            char e = RandomElement;
            stos.Push(e);
            stos.Pop();
            //char[] tabPo = stos.ToArray();

            //CollectionAssert.AreEqual(tabPrzed, tabPo);
        }

        [TestMethod]
        public void Peek_ZwracaOstatnioWstawionyElement()
        {
            stos = new StosWLiscie<char>();
            char e = RandomElement;

            stos.Push(e);

            Assert.AreEqual(stos.Peek, e);
        }

        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PeekDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWLiscie<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PopDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWLiscie<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        // indexer
        [TestMethod]
        public void Indexer()
        {
            stos = new StosWLiscie<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            for (int i = 0; i < stos.Count; i++)
            {
                Console.WriteLine(stos[i]);
            }
        }
    }

}