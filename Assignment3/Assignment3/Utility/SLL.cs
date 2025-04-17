using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Assignment3.ProblemDomain;

namespace Assignment3.Utility
{
    [Serializable]
    public class SLL : ILinkedListADT
    {
        public Node head;
        public int count;

        public bool IsEmpty() => head == null;

        public void Clear()
        {
            head = null;
            count = 0;
        }


        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            count++;
        }
        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            if (index == 0)
            {
                AddFirst(value);
                return;
            }
            Node newNode = new Node(value);
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        public int Count()
        {
            return count;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Cannot remove from an empty list");
            }
            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Cannot remove from an empty list");
            }
            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            count--;
        }

        public User Get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            count--;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            int currentIndex = 0;
            while (current != null && currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }

            if (current == null)
                throw new IndexOutOfRangeException();

            return current.Data;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }
        public bool Contains(User value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            Node next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }


    }
}
