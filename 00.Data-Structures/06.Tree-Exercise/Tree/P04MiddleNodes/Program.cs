﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04MiddleNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace P03LeafNodes
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

                List<int> middleNodes = tree.Values.Where(x => x.Parent != null && x.Children.Count > 0)
                    .Select(n => n.Value)
                    .OrderBy(n => n)
                    .ToList();

                Console.WriteLine($"Middle nodes: {string.Join(" ", middleNodes)}");
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

}
