using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace OOP
{
    [TestClass]
    public class Vector : IEnumerable
    {
        //Class variables               

        private object[] data;
        private int count;

        //Class constructors

        public Vector()
        {
            this.count = 0;
            this.data = new object[8];
        }

        public Vector(object[] data)
        {
            count = data.Length;
            this.data = new object[count];
            Array.Copy(data, this.data, count);
            //this.data = data;

        }

        //Class Methods



        public void Add(object obj)
        {
            count++;
            if (count >= data.Length)
            {
                Array.Resize(ref data, 2 * data.Length);
            }
            data[count - 1] = obj;

        }
        public void Insert(int position, object obj)
        {
            count++;
            if (count >= data.Length)
            {
                Array.Resize(ref data, 2 * data.Length);
            }
            for (int i = data.Length - 2; i >= position; i--)
            {
                data[i + 1] = data[i];
            }
            data[position] = obj;

        }
        public void Remove(object obj)
        {
            bool found = false;
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i].Equals(obj))
                {
                    found = true;
                }
                if (found)
                {
                    data[i] = data[i + 1];
                }
            }
            data[count - 1] = null;
            count--;
        }

        public void Remove(int index)
        {
            bool found = false;
            for (int i = index; i < data.Length - 1; i++)
            {
                if (i == index)
                {
                    found = true;
                }
                if (found)
                {
                    data[i] = data[i + 1];
                }
            }
            data[count - 1] = null;
            count--;
        }

        public object GetElementAtIndex(int index)
        {
            for (int i = 0; i < data.Length - 1; i++)
                if (i == index)
                    return data[i];
            return null;
        }

        public int Count()
        {
            return count;
        }
        public object[] GetData()
        {
            return data;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        [TestMethod]
        public void Enumerator()
        {
            object[] localData = new object[4] { 3, 7, 5, 8 };
            Vector vector = new Vector(localData);
            Enumerator enumerator = new Enumerator(vector);
            enumerator.MoveNext();
            object objCurrent = enumerator.Current;
            enumerator.MoveNext();
            enumerator.MoveNext();
            Assert.AreEqual(true, enumerator.MoveNext());

            object newObj = enumerator.Current;
            Assert.AreEqual(3, objCurrent);
        }

        [TestMethod]
        public void AddNewObject()
        {
            object[] localData = new object[] { 3, 7, 5, 8 };
            Vector vector = new Vector(localData);
            object obj = 2;
            object[] expectedValue = new object[] { 3, 7, 5, 8, 2, null, null, null };
            vector.Add(obj);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
            Assert.AreEqual(5, vector.Count());
        }

        [TestMethod]
        public void CountObjects()
        {
            object[] localData = new object[4] { 3, 7, 5, 8 };
            Vector vector = new Vector(localData);
            Assert.AreEqual(4, vector.Count());
        }

        [TestMethod]
        public void InsertNewObject()
        {
            object[] localData = new object[] { 3, 7, 5, 8 };
            Vector vector = new Vector(localData);
            object obj = 2;
            object[] expectedValue = new object[] { 3, 7, 2, 5, 8, null, null, null };
            vector.Insert(2, obj);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
        }

        [TestMethod]
        public void RemoveObject()
        {
            object[] localData = new object[] { 3, 7, 2, 5, 8 };
            Vector vector = new Vector(localData);
            object obj = 2;
            object[] expectedValue = new object[] { 3, 7, 5, 8, null };
            vector.Remove(obj);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
        }

        [TestMethod]
        public void RemoveObjectByIndex()
        {
            object[] localData = new object[] { 3, 7, 2, 5, 8 };
            Vector vector = new Vector(localData);
            int index = 1;
            object[] expectedValue = new object[] { 3, 2, 5, 8, null };
            vector.Remove(index);
            CollectionAssert.AreEqual(expectedValue, vector.GetData());
        }

        [TestMethod]
        public void GetElement()
        {
            object[] localData = new object[4] { 3, 7, 5, 8 };
            Vector vector = new Vector(localData);
            int position = 1;
            Assert.AreEqual(7, vector.GetElementAtIndex(position));
        }
    }
}
