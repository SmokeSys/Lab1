using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace lab1queue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountInDecreasingTests()
        {            
            var q = new Queuel<int>();
            for (int i = 0; i < 100; i++)
            {
                q.Enqueue(i);
            }

            Assert.AreEqual(100, q.Count);

            q.Peek();
            Assert.AreEqual(100, q.Count);

            for (int i = 0; i < 50; i++)
                q.Dequeue();
            Assert.AreEqual(50, q.Count);
        }

        [TestMethod]
        public void ItemsExsistsAfterAdding()
        {
            var q = new Queuel<int>();
            for (int i = 0; i < 20; i++)
            {
                q.Enqueue(i);
                Assert.AreEqual(i + 1, q.Count);
                Assert.AreEqual(true, q.Contains(i));
            }
        }

        [TestMethod]
        public void ItemsDNtExsistsAfterRemoving()
        {
            var q = new Queuel<int>();
            for (int i = 0; i < 20; i++)
            {
                q.Enqueue(i);
            }

            for (int i = 0; i < 20; i++)
            {
                int temp = q.Dequeue();
                Assert.AreEqual(i, temp);
                Assert.AreEqual(20 - 1 - i, q.Count);
                Assert.AreEqual(false, q.Contains(temp));
            }
        }

        [TestMethod]
        public void CountAfterPeek()
        {
            var q = new Queuel<int>();
            for (int i = 0; i < 20; i++)
            {
                q.Enqueue(i);
            }

            q.Peek();
            Assert.AreEqual(20, q.Count);

            q.Enqueue(20);

            q.Peek();
            Assert.AreEqual(21, q.Count);
        }

        [TestMethod]
        public void ContainsIsCorrect()
        {
            var q = new Queuel<int>();
            for (int i = 0; i < 100; i++)
            {
                q.Enqueue(i);
            }

            Assert.AreEqual(false, q.Contains(-1));
            Assert.AreEqual(true, q.Contains(50));

            q.Enqueue(150);
            Assert.AreEqual(true, q.Contains(150));

            q.Dequeue();
            Assert.AreEqual(false, q.Contains(0));

            q.Peek();
            Assert.AreEqual(true, q.Contains(1));
        }
       

        [TestMethod]
        public void CorrectOrder()
        {
            var q = new Queuel<int>();
            int[] a = new int[100];
            Random r = new Random();
            for(int i = 0; i < a.Length; i++)
                a[i] = r.Next(0, 1000);
            foreach (var t in a)
                q.Enqueue(t);

            for (int i = 0; i < a.Length; i++)
            {
                int temp = q.Dequeue();
                Assert.AreEqual(a[i], temp);
            }
        }
    }
}
