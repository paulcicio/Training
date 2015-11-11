﻿using System;
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
    }
}
