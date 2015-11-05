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
        }

        public Vector(object[] data)
        {
            this.data = data;
            count = data.Length;
        }

        //Class Methods

        public void Add(object[] obj)
        {
            count++;
            Array.Resize(ref data, 2 * data.Length);
            data[count - 1] = obj[0];

        }
        public void Insert(int position, object obj)
        {
            count++;
            if (data.Length == 4)
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
            for (int i = 0; i < data.Length-1; i++)
            {
                if (data[i].Equals(obj))
                {                    
                    found = true;
                }
                if (found == true)
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
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (i== index)
                {
                    found = true;
                }
                if (found == true)
                {
                    data[i] = data[i + 1];
                }

            }
            data[count - 1] = null;
            count--;
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
            {
                //
                // Summary:
                //     Gets the current element in the collection.
                //
                // Returns:
                //     The current element in the collection.
                //object Current { get; }

                //
                // Summary:
                //     Advances the enumerator to the next element of the collection.
                //
                // Returns:
                //     true if the enumerator was successfully advanced to the next element; false if
                //     the enumerator has passed the end of the collection.
                //
                // Exceptions:
                //   T:System.InvalidOperationException:
                //     The collection was modified after the enumerator was created.
                //bool MoveNext();
                //
                // Summary:
                //     Sets the enumerator to its initial position, which is before the first element
                //     in the collection.
                //
                // Exceptions:
                //   T:System.InvalidOperationException:
                //     The collection was modified after the enumerator was created.
                //void Reset();
            }
            throw new NotImplementedException();
        }

        [TestMethod]
        public void AddNewObject()
        {
            object[] localData = new object[4] { 3, 7, 5, 8 };
            Vector vector = new Vector(localData);
            object[] obj = new object[] { 2 };
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
            object[] localData = new object[] { 3, 7, 2, 5, 8};
            Vector vector = new Vector(localData);
            object obj = 2;
            object[] expectedValue = new object[] { 3, 7, 5, 8, null};
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
    }
}
