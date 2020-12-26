using System;
using System.Collections;
using System.Collections.Generic;

class LinkedStack<T> : IEnumerable<T>
{
    public int Count { get; set; }
    private StackNode top;

    public void Push(T element)
    {
        this.top = new StackNode(element, this.top);

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T result = this.top.Value;
        this.top = this.top.Next;
        this.Count--;

        return result;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T result = this.top.Value;

        return result;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        StackNode current = this.top;
        int index = 0;

        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }

        return array;
    }

    public IEnumerator<T> GetEnumerator()
    {
        StackNode current = this.top;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class StackNode
    {
        public T Value { get; set; }
        public StackNode Next { get; set; }

        public StackNode(T value, StackNode next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
