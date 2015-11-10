using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace OOP
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void Traverse()
        {            
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            list.Insert(3);
            list.TraverseList();
        }
    }
}
