using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    public Node root;

    public BinarySearchTree()
    {
        this.root = null;
    }
   
    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
            return;
        }

        Node parent = null;
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(value);
            if (compare > 0)//current.Value > value
            {
                parent = current;
                current = current.Left;
            }
            else if (compare < 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                return;
            }
        }

        Node newNode = new Node(value);
        if (parent.Value.CompareTo(value) > 0)//parent.Value > value
        {
            parent.Left = newNode;
        }
        else//parent.Value < value
        {
            parent.Right = newNode;
        }
    }

    public bool Contains(T value)
    {
        throw new NotImplementedException();
    }

    public void DeleteMin()
    {
        throw new NotImplementedException();
    }

    public BinarySearchTree<T> Search(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        throw new NotImplementedException();
    }

    public void EachInOrder(Action<T> action)
    {
        throw new NotImplementedException();
    }

    public class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        
    }
}
