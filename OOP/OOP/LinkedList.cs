using OOP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class SimpleLinkedList<T> : ICollection<T>
    {
        Node begin;
        private int count;

        private class Node
        {
            public T value;
            public Node next;

            public override bool Equals(object obj)
            {
                if (obj is T)
                {
                    var equals = value?.Equals(obj);
                    return equals.HasValue && equals.Value;
                }
                else
                {
                    if (obj is Node)
                    {
                        var equals = next?.Equals(obj);
                        return equals.Value && equals.HasValue;
                    }
                    return false;
                }
            }
        }

        public class EnumeratorList : IEnumerator<T>
        {
            private SimpleLinkedList<T> linkedList;
            Node currentNode;
            private bool isAtStart;
            public EnumeratorList(SimpleLinkedList<T> linkedList)
            {
                this.linkedList = linkedList;
                Reset();
            }

            public void Reset()
            {
                currentNode = null;
                isAtStart = true;
            }

            public bool MoveNext()
            {
                if (isAtStart)
                {
                    currentNode = linkedList.begin;
                    isAtStart = false;
                }
                else
                {
                    currentNode = currentNode?.next;
                }
                return currentNode != null;
            }

            public void Dispose()
            {

            }

            public object Current
            {

                get
                {
                    if (currentNode != null)
                        return currentNode.value;
                    else
                        return null;
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return currentNode.value;
                }
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        int ICollection<T>.Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorList(this);
        }

        public void Add(T item)
        {
            Node toAdd = new Node();
            toAdd.value = item;
            Node current = begin;
            if (begin == null)
            {
                begin = toAdd;
                count++;
            }
            else
            {
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
                count++;
            }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException();
            Node toAdd = new Node();
            toAdd.value = item;
            Node current = begin;
            if (count == 0 || index == 0)
            {
                begin = toAdd;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                toAdd.next = current.next;
                current.next = toAdd;
            }
            count++;
        }

        public void Clear()
        {
            begin = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            Node temp = begin;
            bool contains = false;
            while (!(contains = temp.value.Equals(item)) && temp.next != null)
            {
                temp = temp.next;
            }
            return contains;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > count)
                throw new ArgumentOutOfRangeException();
            if (array.Length==0)
                throw new ArgumentNullException();
            if (count > (array.Length - arrayIndex))
                throw new ArgumentException();
            for (Node current = begin; current != null; current = current.next)            
                array[arrayIndex++] = current.value;                        
        }

        public bool Remove(T item)
        {
            for (var current = begin; current.next != null; current = current.next)
            {
                var next = current.next;
                if (current.Equals(item) && next != null)
                {
                    current = next;
                    begin = current;
                    count--;
                    return true;
                }
            }
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new EnumeratorList(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

