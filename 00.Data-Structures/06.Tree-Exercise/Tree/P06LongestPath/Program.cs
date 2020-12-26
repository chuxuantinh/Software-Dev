using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06LongestPath
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

            Stack<Tree<int>> stack = new Stack<Tree<int>>();
            Tree<int> root = tree.FirstOrDefault(x => x.Value.Parent == null).Value;

            stack.Push(root);

            Tree<int> deepestNode = null;

            while (stack.Count > 0)
            {
                Tree<int> current = stack.Pop();

                if (current != null && current.Children.Count > 0)
                {
                    deepestNode = current.Children.ElementAt(0);

                    foreach (var child in current.Children)
                    {
                        stack.Push(child);
                    }
                }
            }

            Stack<int> path = new Stack<int>();
            Tree<int> currentNode = deepestNode;

            while (currentNode != null)
            {
                path.Push(currentNode.Value);
                currentNode = currentNode.Parent;
            }

            Console.WriteLine("Longest path: " + string.Join(" ", path));
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
