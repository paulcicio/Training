using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace OOP
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void EmptyList()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.ShouldBeEmpty();
        }

        [TestMethod]
        public void Add()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] array = new int[3];
            list.Add(3);
            list.ShouldContain(3);
            list.Add(5);
            list.ShouldContain(5);
            list.Add(7);
            list.ShouldContain(7);
            list.CopyTo(array, 0);
        }

        [TestMethod]
        public void AddAtTail()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] array = new int[3];
            list.AddAtTail(7);            
            list.AddAtTail(3);            
            list.AddAtTail(5);
            list.CopyTo(array, 0);
        }

        [TestMethod]
        public void Clear()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Add(3);            
            list.Add(5);            
            list.Add(7);
            list.Clear();
            list.ShouldBeEmpty();
        }

        [TestMethod]
        public void Contains()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Add(3);
            list.Add(5);
            list.Add(7);
            bool isTrue = list.Contains(7);
            Assert.AreEqual(true, isTrue);
        }

        [TestMethod]
        public void Count()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Add(3);
            list.Add(5);
            list.Add(7);
            int numberOfItems = list.Count;
            Assert.AreEqual(3, numberOfItems);
        }

        [TestMethod]
        public void CopyTo()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] array = new int[3];
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.CopyTo(array, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyToWithNegativeIndex()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] array = new int[3];
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.CopyTo(array, -2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyToWithNullArray()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] array = new int[0];
            list.Add(3);
            list.Add(5);
            list.Add(7);            
            list.CopyTo(array, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyToWithLessSpaceInTheArray()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] array = new int[3];
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.CopyTo(array, 2);
        }

        [TestMethod]
        public void ReverseEnumeratorForASingleItemList()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();            
            list.AddAtTail(2);
            var enumerator = list.GetReverseEnumerable();
            enumerator.ShouldContain(2);
        }

        [TestMethod]
        public void ReverseEnumeratorForAListWithTwoItems()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddAtTail(2);
            list.AddAtTail(5);            
            var enumerator = list.GetReverseEnumerable();
            enumerator.ShouldContain(2);
        }

        [TestMethod]
        public void ReverseEnumeratorForAListWithMultipleItems()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddAtTail(2);
            list.AddAtTail(3);
            list.AddAtTail(5);
            list.AddAtTail(7);
            list.AddAtTail(1);
            var enumerator = list.GetReverseEnumerable();
            enumerator.ShouldContain(5);
        }
    }
}
