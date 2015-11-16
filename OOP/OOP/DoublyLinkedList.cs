using OOP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        Node head;
        Node tail;  
        private int count = 0;

        public class Node
        {
            private T tValue;
            private Node next;
            private Node previous;

            public T TValue
            {
                get { return tValue; }
                set{tValue = value;}
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public Node Previous
            {
                get { return previous; }
                set { previous = value; }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorDoubleList(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            Node toAdd = new Node();
            toAdd.TValue = item;
            Node current = head;
            if (head == null)
            {
                head = toAdd;
                count++;
            }
            else
            {
                Node previous = null;
                while (current.Next != null)
                {
                    previous = current;
                    current = current.Next;
                    toAdd.Previous = current;
                }
                current.Next = toAdd;
                current.Previous = previous;
                count++;
            }

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

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

        public class EnumeratorDoubleList : IEnumerator<T>
        {
            private DoublyLinkedList<T> list;
            Node currentNode;
            private bool isAtStart;
            public EnumeratorDoubleList(DoublyLinkedList<T> list)
            {
                this.list = list;
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
                    currentNode = list.head;                    
                    isAtStart = false;                    
                }
                else
                {
                    list.head = currentNode;
                    currentNode = currentNode?.Next;
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
                        return currentNode.TValue;
                    else
                        return null;
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return currentNode.TValue;
                }
            }
        }
    }
}
