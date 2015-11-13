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
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            list.ShouldBeEmpty();
        }
    }
}
