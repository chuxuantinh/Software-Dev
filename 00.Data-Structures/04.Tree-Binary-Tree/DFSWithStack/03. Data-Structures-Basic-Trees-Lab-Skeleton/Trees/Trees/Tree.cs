using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; private set; }
    public List<Tree<T>> Children { get; private set; }

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public void Print(int indent = 0)
    {
        this.Print(this, indent);
    }

    private void Print(Tree<T> node, int indent)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(node.Value);

        foreach (Tree<T> child in node.Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        Stack<T> result = new Stack<T>();
        Stack<Tree<T>> stack = new Stack<Tree<T>>();

        stack.Push(this);

        while (stack.Count > 0)
        {
            Tree<T> current = stack.Pop();
            result.Push(current.Value);

            foreach (Tree<T> child in current.Children)
            {
                stack.Push(child);
            }
        }

        return result;
    }

    public IEnumerable<T> OrderBFS()
    {
        Queue<Tree<T>> queue = new Queue<Tree<T>>();
        List<T> result = new List<T>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            Tree<T> current = queue.Dequeue();
            result.Add(current.Value);

            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }
}
