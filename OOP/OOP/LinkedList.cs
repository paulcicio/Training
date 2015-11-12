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
        Node<T> begin;
        private int count;

        private class Node<T>
        {
            public T value;
            public Node<T> next;

            public override bool Equals(object obj)
            {
                if (obj is T)
                {
                    var equals = value?.Equals(obj);
                    return equals.HasValue && equals.Value;
                }
                else
                {
                    if (obj is Node<T>)
                    {
                        var equals = next?.Equals(obj);
                        return equals.Value && equals.HasValue;
                    }
                    return base.Equals(obj);
                }
            }
        }

        public class EnumeratorList : IEnumerator<T>
        {
            private SimpleLinkedList<T> linkedList;
            Node<T> currentNode;
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
                //throw new NotImplementedException();
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
            Node<T> toAdd = new Node<T>();
            toAdd.value = item;
            Node<T> current = begin;
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

        public void Clear()
        {
            begin = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> temp = begin;
            bool contains = false;
            while (!(contains = temp.value.Equals(item)) && temp.next != null)
            {
                temp = temp.next;
            }
            return contains;
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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

