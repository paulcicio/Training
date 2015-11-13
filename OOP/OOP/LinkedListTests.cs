using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Should;

namespace OOP
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void ShouldBeEmptyList()
        {            
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            list.ShouldBeEmpty();            
        }

        [TestMethod]
        public void ShouldSupportAddition()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();            
            list.Add(3);
            list.ShouldContain(3);
        }

        [TestMethod]
        public void ShouldRemoveAnItem()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();            
            list.Add(3);            
            list.Add(5);            
            list.Add(7);
            list.Remove(3);
            list.ShouldNotContain(3);
        }

        [TestMethod]
        public void ShouldNotRemoveNonExistentItems()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();            
            list.Add(3);            
            list.Add(5);            
            list.Add(7);
            var oldCount = list.Count;
            list.Remove(8);
            list.Count.Equals(oldCount);
        }

        [TestMethod]
        public void ClearList()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();            
            list.Add(3);            
            list.Add(5);            
            list.Add(7);
            list.Clear();
            list.ShouldBeEmpty();
        }

        [TestMethod]
        public void Contains()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();            
            list.Add(3);            
            list.Add(5);            
            list.Add(7);
            bool isTrue = list.Contains(7);
            Assert.AreEqual(true, isTrue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertThrowException()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.Insert(-1, 4);
            list.ShouldContain(4);
        }

        [TestMethod]        
        public void InsertAtIndex()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();            
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.Insert(1, 4);
            list.ShouldContain(4);
        }

        [TestMethod]
        public void CopyTo()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            int[] array = new int[4];
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.CopyTo(array, 1);            
        }
    }
}
