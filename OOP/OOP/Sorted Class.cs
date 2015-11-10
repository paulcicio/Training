using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class SortedVector<T> : Vector<T> where T : IComparable
    {
        public SortedVector()
        {
            this.count = 0;
            this.data = new T[8];
        }

        public SortedVector(T[] data)
        {
            count = data.Length;
            this.data = new T[count];
            Sort(data);
            Array.Copy(data, this.data, count);
            
        }

        public override void Add(T obj)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                if (obj.CompareTo(data[i]) >= 0)
                {
                    Insert(i + 1, obj);
                    break;
                }
            }
           // Insert(0, obj);
        }       

        private void Sort(T[] data)
        {
            for (int i = 1; i < count; i++)
            {
                for (int k = i; k > 0 && data[k].CompareTo(data[k - 1]) <= 0; k--)
                {
                    var temp = data[k - 1];
                    data[k - 1] = data[k];
                    data[k] = temp;
                }
            }
        }

        public int Find(T obj)
        {
            int min = 0, max = count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (data[mid].CompareTo(obj) == 0)
                {
                    return mid;
                }
                else if (data[mid].CompareTo(obj) >= 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return 0;
        }       
    }
}

