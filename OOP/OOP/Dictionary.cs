using OOP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Dictionary<TKey, TValue> 
    {
        private Entry[] entries= new Entry[100];
        private int[] buckets = new int[100]; 
        private int count;
        private int nextEntry;
        private int freeIndex;

        public int Count
        {
            get
            {
                return count;
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

        public void Add(TKey key, TValue value)
        {
            int hashCode = key.GetHashCode() & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length;
            int index;
            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next)
            {
                if (entries[i].hashCode == hashCode && Equals(entries[i].key, key))
                {
                    entries[i].value = value;
                    return;
                }
                else
                    if (entries[i].hashCode == hashCode && !Equals(entries[i].key, key))
                {
                    index = freeIndex;
                    freeIndex = entries[index].next;
                }
            }

            if (count == entries.Length)
            {
                Resize();
                targetBucket = hashCode % buckets.Length;
            }
            index = count;
            count++;
            entries[index].hashCode = hashCode;
            entries[index].next = buckets[targetBucket];
            entries[index].key = key;
            entries[index].value = value;
            buckets[targetBucket] = index;
        }

        private void Resize()
        {
            throw new NotImplementedException();
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int GenerateHashCode(TKey key)
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

        public bool ContainsKey(TKey key)
        {
            int targetBucket = GenerateHashCode(key);
            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next)
            {
                if (Equals(entries[i].key, key))
                    return true;
            }
            return false;

        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TValue item)
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
            public TKey key;
            public TValue value;
        }        
    }

    public class Movie
    {
        public string Title;
        public int Year;
    }
}

