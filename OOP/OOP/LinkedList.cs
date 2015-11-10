using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class SimpleLinkedList<T>
    {
        Node begin;

        private class Node
        {
            public T value;
            public Node next;
        }

        private int count;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public T TraverseList()
        {
            Node currentNode = begin;
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
            }
            return currentNode.value;
        }

        public void Insert(T value)
        {
            Node toAdd = new Node();
            toAdd.value = value;
            Node current = begin;
            if (begin == null)
            {
                begin = toAdd;
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
    }
}

