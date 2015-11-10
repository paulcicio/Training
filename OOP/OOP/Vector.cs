using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Vector<T> : IEnumerable
    {
        protected T[] data;
        protected int count;

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
    }
}
