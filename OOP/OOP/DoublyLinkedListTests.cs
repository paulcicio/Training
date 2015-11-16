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
        public void AddFirst()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Add(3);
            list.ShouldContain(3);
            list.Add(5);
            list.ShouldContain(5);
        }
    }
}
