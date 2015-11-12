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
            int toAdd = 3;
            list.Add(toAdd);
            list.ShouldContain(3);
        }

        [TestMethod]
        public void ShouldRemoveAnItem()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            int toAdd = 3;
            list.Add(toAdd);
            int toAdd2 = 5;
            list.Add(toAdd2);
            int toAdd3 = 7;
            list.Add(toAdd3);
            list.Remove(3);
            list.ShouldNotContain(3);
        }

        [TestMethod]
        public void ShouldNotRemoveNonExistentItems()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            int toAdd = 3;
            list.Add(toAdd);
            int toAdd2 = 5;
            list.Add(toAdd2);
            int toAdd3 = 7;
            list.Add(toAdd3);
            var oldCount = list.Count;
            list.Remove(8);
            list.Count.Equals(oldCount);
        }

        [TestMethod]
        public void ClearList()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            int toAdd = 3;
            list.Add(toAdd);
            int toAdd2 = 5;
            list.Add(toAdd2);
            int toAdd3 = 7;
            list.Add(toAdd3);
            list.Clear();
            list.ShouldBeEmpty();
        }

        [TestMethod]
        public void Contains()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            int toAdd = 3;
            list.Add(toAdd);
            int toAdd2 = 5;
            list.Add(toAdd2);
            int toAdd3 = 7;
            list.Add(toAdd3);
            bool isTrue = list.Contains(7);
            Assert.AreEqual(true, isTrue);
        }
    }
}
