using System;

public class ArrayStack<T>
{
    private const int InitialCapacity = 16;
    private T[] Elements;

    public ArrayStack(int capacity = InitialCapacity)
    {
        Elements = new T[capacity];
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (Elements.Length == Count)
            Grow();

        Elements[Count++] = element;
    }


    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException();

        Count--;
        var value = Elements[Count];
        Elements[Count] = default(T);

        return value;
    }

    public T[] ToArray()
    {
        var array = new T[Count];
        int index = 0;
        for (int i = this.Count - 1; i >= 0; i--)
        {
            array[index++] = Elements[i];
        }
        return array;
    }

    private void Grow()
    {
        var newStack = new T[2 * Elements.Length];
        Array.Copy(Elements, newStack, Elements.Length);
        Elements = newStack;
    }
}

