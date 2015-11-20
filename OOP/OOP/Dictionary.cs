using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Dictionary<Key, value> : ICollection
    {
        //private Bucket[] buckets = new Bucket[1000];
        private Entry[] entries;
        private int[] buckets; //every value in this array points to an index in the entries array
        private int count;

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Key key, Movie movie)
        {
                                 
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int GenerateHashCode(Key key)
        {
            var hashCode = key.GetHashCode() & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length;
            return targetBucket;
        }

        public void Clear()
        {
            if (count > 0)
            {
                for (int i = 0; i < buckets.Length; i++) buckets[i] = -1;                
                count = 0;
            }
        }

        public bool Contains(value item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(value[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(value item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        private struct Entry
        {
            public int hashCode;
            public int next;
            public Key key;
            public value value;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var bucket in buckets)
                if (bucket != null)
                    foreach (Entry entry in entries)
                        yield return entry.value;
        }
        //private class Bucket : IEnumerable
        //{
        //    public List<Entry> data = new List<Entry>();
        //    public void Add(Key key, value value)
        //    {
        //        data.Add(new Entry
        //        {
        //            key = key,
        //            value = value
        //        });

        //    }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class Movie
    {
        public string Title;
        public int Year;
    }

