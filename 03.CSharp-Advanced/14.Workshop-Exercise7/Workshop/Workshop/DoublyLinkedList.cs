using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class DoublyLinkedList
    {
        private class LinkNode
        {
            public LinkNode(object value)
            {
                Value = value;
            }

            public object Value { get; private set; }

            public LinkNode NextNode { get; set; }

            public LinkNode PreviousNode { get; set; }

        }

        private LinkNode head;
        private LinkNode tail;

        public int Count { get; private set; }

        public void AddFirst(object value)
        {
            LinkNode newHead = new LinkNode(value);

            if (this.Count == 0)
            {
                tail = head = newHead;
            }
            else
            {
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(object value)
        {
            LinkNode newTail = new LinkNode(value);
            if (Count == 0)
            {
                tail = head = newTail;
            }
            else
            {
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }
            Count++;
        }

        public object RemoveFirst()
        {
            CheckIfEmptyThrowException();
            object firstElement = head.Value;
            head = head.NextNode;
            if (head == null)
            {
                tail = null;
            }
            else
            {
                head.PreviousNode = null;
            }
            Count--;
            return firstElement;
        }

        public object RemoveLast()
        {
            CheckIfEmptyThrowException();
            object lastElement = tail.Value;
            tail = tail.PreviousNode;
            if (tail == null)
            {
                head = null;
            }
            else
            {
                tail.NextNode = null;
            }
            Count--;
            return lastElement;
        }

        public void Print(Action<object> action)
        {
            LinkNode currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public bool Contains(object value)
        {
            LinkNode currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }
            return false;
        }

        public object[] ToArray()
        {
            object[] array = new object[Count];
            var currentNode = head;
            int counter = 0;
            while (currentNode != null)
            {
                array[counter++] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }
            return array;
        }

        public List<object> ToList()
        {
            List<object> list = new List<object>(Count);
            var currentNode = head;
            while (currentNode != null)
            {
                list.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            return list;
        }

        private void CheckIfEmptyThrowException()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty");
            }
        }
    }
}
