using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace OOP
{
    [TestClass]
    public class VectorTests
    {

        [TestMethod]
        public void Enumerator()
        {
            int[] localData = new int[4] { 3, 7, 5, 8 };
            Vector<int> vector = new Vector<int>(localData);
            Enumerator<int> enumerator = new Enumerator<int>(vector);
            enumerator.MoveNext();
            object objCurrent = enumerator.Current;
            enumerator.MoveNext();
            enumerator.MoveNext();
            Assert.AreEqual(true, enumerator.MoveNext());
            object newObj = enumerator.Current;
            Assert.AreEqual(3, objCurrent);
        }

        [TestMethod]
        public void SortedVector()
        {
            int[] localData = new int[4] { 3, 7, 5, 8 };
            SortedVector<int> vector = new SortedVector<int>(localData);
            int actualValue = vector.Find(7);
            Assert.AreEqual(2, actualValue);
            int obj = 6;
            int[] expectedValue = {3, 5, 6, 7, 8, 0, 0, 0 };
            vector.Add(obj);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
        }

        [TestMethod]
        public void AddNewObject()
        {
            int[] localData = new int[] { 3, 7, 5, 8 };
            Vector<int> vector = new Vector<int>(localData);
            int obj = 2;
            int[] expectedValue = new int[] { 3, 7, 5, 8, 2, 0, 0, 0 };
            vector.Add(obj);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
            Assert.AreEqual(5, vector.Count());
        }

        [TestMethod]
        public void CountObjects()
        {
            int[] localData = new int[4] { 3, 7, 5, 8 };
            Vector<int> vector = new Vector<int>(localData);
            Assert.AreEqual(4, vector.Count());
        }

        [TestMethod]
        public void InsertNewObject()
        {
            int[] localData = new int[] { 3, 7, 5, 8 };
            Vector<int> vector = new Vector<int>(localData);
            int obj = 2;
            int[] expectedValue = new int[] { 3, 7, 2, 5, 8, 0, 0, 0 };
            vector.Insert(2, obj);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
        }

        [TestMethod]
        public void RemoveObject()
        {
            int[] localData = new int[] { 3, 7, 2, 5, 8 };
            Vector<int> vector = new Vector<int>(localData);
            int obj = 2;
            int[] expectedValue = new int[] { 3, 7, 5, 8, 0 };
            vector.Remove(obj);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
        }

        [TestMethod]
        public void RemoveObjectByIndex()
        {
            int[] localData = new int[] { 3, 7, 2, 5, 8 };
            Vector<int> vector = new Vector<int>(localData);
            int index = 1;
            int[] expectedValue = new int[] { 3, 2, 5, 8, 0 };
            vector.RemoveByIndex(index);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
        }

        [TestMethod]
        public void GetElement()
        {
            int[] localData = new int[4] { 3, 7, 5, 8 };
            Vector<int> vector = new Vector<int>(localData);
            int position = 1;
            Assert.AreEqual(7, vector.GetElementAtIndex(position));
        }
    }
}

