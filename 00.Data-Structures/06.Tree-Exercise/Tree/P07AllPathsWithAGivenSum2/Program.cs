using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07AllPathsWithAGivenSum2
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

            int sum = int.Parse(Console.ReadLine());

            Console.WriteLine($"Paths of sum {sum}:");

            List<List<Tree<int>>> paths = GetPathsToAllNodes();

            Stack<List<int>> pathsOfRightSum = new Stack<List<int>>();
            foreach (var path in paths)
            {
                List<int> route = new List<int>();
                int pathSum = 0;
                foreach (var node in path)
                {
                    route.Add(node.Value);
                    pathSum += node.Value;
                }

                if (pathSum == sum)
                {
                    pathsOfRightSum.Push(route);
                }
            }

            while (pathsOfRightSum.Count > 0)
            {
                List<int> route = pathsOfRightSum.Pop();
                Console.WriteLine(string.Join(" ", route));
            }
        }

        private static List<List<Tree<int>>> GetPathsToAllNodes()
        {
            List<List<Tree<int>>> paths = new List<List<Tree<int>>>();
            Stack<List<Tree<int>>> pathsStack = new Stack<List<Tree<int>>>();

            Tree<int> root = tree.FirstOrDefault(x => x.Value.Parent == null).Value;

            pathsStack.Push(new List<Tree<int>> { root });

            while (pathsStack.Count > 0)
            {
                List<Tree<int>> currentList = pathsStack.Pop();

                if (currentList.Last().Children.Count == 0)
                {
                    paths.Add(currentList);
                }
                else
                {
                    foreach (var child in currentList.Last().Children)
                    {
                        pathsStack.Push(new List<Tree<int>>(currentList) { child });
                    }
                }
            }

            return paths;
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
