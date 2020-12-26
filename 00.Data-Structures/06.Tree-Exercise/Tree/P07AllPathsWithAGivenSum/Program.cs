﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07AllPathsWithAGivenSum
{
    class Program
    {
        static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                int[] nodes = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int parent = nodes[0];
                int child = nodes[1];

                if (!tree.ContainsKey(parent))
                {
                    tree.Add(parent, new Tree<int>(parent));
                }

                if (!tree.ContainsKey(child))
                {
                    tree.Add(child, new Tree<int>(child));
                }

                Tree<int> parentNode = tree[parent];
                Tree<int> childNode = tree[child];
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }
            //Not sure if we reach the leaves!
            Tree<int> root = tree.FirstOrDefault(x => x.Value.Parent == null).Value;

            int sum = int.Parse(Console.ReadLine());

            Console.WriteLine($"Paths of sum {sum}:");
            DFS(root, sum);
        }

        static void DFS(Tree<int> node, int targetSum, int sum = 0)
        {
            sum += node.Value;

            if (sum == targetSum && node.Children.Count == 0)
            {
                PrintPath(node);
            }

            foreach (var child in node.Children)
            {
                DFS(child, targetSum, sum);
            }
        }

        private static void PrintPath(Tree<int> node)
        {
            Stack<int> path = new Stack<int>();

            Tree<int> start = node;
            path.Push(start.Value);

            while (start.Parent != null)
            {
                start = start.Parent;
                path.Push(start.Value);
            }

            Console.WriteLine(string.Join(" ", path));
        }
    }

    class Tree<T>
    {
        public T Value { get; set; }
        public List<Tree<T>> Children { get; set; }
        public Tree<T> Parent { get; set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>(children);
        }

        public void Print(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}{this.Value}");
            foreach (var child in this.Children)
            {
                child.Print(indent + 2);
            }
        }
    }
}
