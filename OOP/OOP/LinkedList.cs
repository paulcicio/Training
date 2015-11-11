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
        }

        public class EnumeratorList : IEnumerator<T>
        {
            private SimpleLinkedList<T> linkedList;
            Node<T> currentNode;
            public EnumeratorList(SimpleLinkedList<T> linkedList)
            {
                this.linkedList = linkedList;
                Reset();
            }

            public void Reset()
            {
                currentNode = linkedList.begin;
            }

            public bool MoveNext()
            {
                if (currentNode == null)
                    return false;
                else
                {
                    currentNode = currentNode?.next;
                }
                return true;
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
                    throw new NotImplementedException();
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

        //public T TraverseList()
        //{
        //    Node currentNode = begin;
        //    while (currentNode.next != null)
        //    {
        //        currentNode = currentNode.next;
        //    }
        //    return currentNode.value;
        //}

        //public void Add(T value)
        //{
        //    Node toAdd = new Node();
        //    toAdd.value = value;
        //    Node current = begin;
        //    if (begin == null)
        //    {
        //        begin = toAdd;
        //    }
        //    else
        //    {
        //        while (current.next != null)
        //        {
        //            current = current.next;
        //        }
        //        current.next = toAdd;
        //        count++;
        //    }
        //}

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorList(this);
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
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

