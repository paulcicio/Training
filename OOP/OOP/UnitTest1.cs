using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace OOP
{
    [TestClass]
    public class Vector <T> : IEnumerable
    {
        private T[] data;
        private int count;
        
        public Vector()
        {
            this.count = 0;
            this.data = new T[8];
        }

        public Vector(T[] data)
        {
            count = data.Length;
            this.data = new T[count];
            Array.Copy(data, this.data, count);
        
        }
                
        public virtual void Add(T obj)
        {
            ResizeAndIncrementCounter();
            data[count - 1] = obj;

        }

        private void ResizeAndIncrementCounter()
        {
            count++;
            if (count >= data.Length)
            {
                Array.Resize(ref data, 2 * data.Length);
            }
        }

        public void Insert(int position, T obj)
        {
            ResizeAndIncrementCounter();
            for (int i = data.Length - 2; i >= position; i--)
            {
                data[i + 1] = data[i];
            }
            data[position] = obj;

        }
        public void Remove(T obj)
        {
            int position = GetIndexOfElement(obj);
            RemoveByIndex(position);           
        }

        public void RemoveByIndex(int index)
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
            data[count - 1] = default(T);
            count--;
        }

        public T GetElementAtIndex(int index)
        {
            for (int i = 0; i < data.Length; i++)
                if (i == index)
                    return data[i];
            return default(T);
        }

        public int GetIndexOfElement(T obj)
        {
            for (int i = 0; i < data.Length - 1; i++)            
                if (data[i].Equals(obj))                
                    return i;
            return -1;
                            
        }

        public int Count()
        {
            return count;
        }
        public T[] GetData()
        {
            return data;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator<T>(this);
        }


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
            Vector<int> vector = new Vector<int>(localData);
            Enumerator<int> enumerator = new Enumerator<int>(vector);
            enumerator.MoveNext();
            object objCurrent = enumerator.Current;
            enumerator.MoveNext();
            enumerator.MoveNext();
            Assert.AreEqual(true, enumerator.MoveNext());
            object newObj = enumerator.Current;
            Assert.AreEqual(3, objCurrent);
            int obj = 2;
            vector.Add(obj);
            int[] expectedValue = { 2, 3, 5, 7, 8 };
            Assert.AreEqual(expectedValue, vector.GetData());
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
