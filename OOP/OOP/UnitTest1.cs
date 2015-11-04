using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace OOP
{
    [TestClass]
    public class Vector: IEnumerable
    {   
        //Class variables               

        private object[] data;
        private int count;

        //Class constructors

        public Vector(object[] _data)
        {
            data = _data;
            count = data.Length;
        }

        //Class Methods

        public void Add(object obj)
        {
            object newObject = new object[8];
            count++;
            Array.Resize(ref data, 2 * data.Length);
            data[count-1] = newObject;
        }
        public void Insert(int position, object obj) { }
        public void Remove(object obj) { }
        public void Remove(int index) { }
        public void Count() { }

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
        public void TestMethod1()
        {
        }


    }
}
