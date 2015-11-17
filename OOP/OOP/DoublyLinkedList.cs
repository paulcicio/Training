﻿using OOP;
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
                set { tValue = value; }
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

        public void Add(T item) //Insert at the beginning of the list
        {
            Node toAdd = new Node();
            toAdd.TValue = item;
            Node current = head;
            if (head == null) //Empty list
            {
                head = tail = toAdd;               
            }
            else
            {
                toAdd.Next = current;
                toAdd.Previous = null;
                head = toAdd;                            
            }
            count++;
        }

        public void AddAtTail(T item)
        {
            Node toAdd = new Node();
            toAdd.TValue = item;
            Node current = tail;
            if (head == null) //Empty list
            {
                head = tail = toAdd;
            }
            else
            {
                toAdd.Next = null;
                current.Next = toAdd;
                toAdd.Previous = current;
                tail = toAdd;
            }
            count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            Node currentNode = head;
            bool contains = false;
            while (!(contains = currentNode.TValue.Equals(item)) && currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            return contains;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > count)
                throw new ArgumentOutOfRangeException();
            if (array.Length == 0)
                throw new ArgumentNullException();
            if (count > (array.Length - arrayIndex))
                throw new ArgumentException();
            for (Node current = head; current != null; current = current.Next)
                array[arrayIndex++] = current.TValue;
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

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

        internal IEnumerable<T> GetReverseEnumerable()
        {
            for (Node current = tail; current != null; current = current.Previous)
                yield return current.TValue;
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
