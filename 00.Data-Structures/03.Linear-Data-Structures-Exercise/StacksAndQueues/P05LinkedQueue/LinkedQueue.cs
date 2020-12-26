using System;


class LinkedQueue<T>
{
    private QueueNode<T> Head;
    private QueueNode<T> Tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        QueueNode<T> newNode = new QueueNode<T>();// { Value = element };
        newNode.Value = element;

        if (this.Count == 0)
        {
            this.Head = newNode;
            this.Tail = newNode;
        }
        else
        {
            this.Tail.NextNode = newNode;
            newNode.PrevNode = this.Tail;
            this.Tail = newNode;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T value = this.Head.Value;

        this.Head.NextNode.PrevNode = null;
        this.Head = this.Head.NextNode;

        this.Count--;

        return value;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        QueueNode<T> current = this.Head;
        int index = 0;

        while (current != null)
        {
            array[index++] = current.Value;
            current = current.NextNode;
        }

        return array;
    }

    private class QueueNode<T>
    {
        public T Value { get; set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }
    }
}

