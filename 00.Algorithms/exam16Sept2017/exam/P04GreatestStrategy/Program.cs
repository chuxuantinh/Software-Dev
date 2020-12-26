using System;
using System.Collections.Generic;

namespace P04GreatestStrategy
{
    class Program
    {
        static Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
        static Dictionary<int, HashSet<int>> disconnected = new Dictionary<int, HashSet<int>>();

        static void Main()
        {
            var args = Console.ReadLine().Split();

            var nodes = int.Parse(args[0]);
            var connections = int.Parse(args[1]);
            var root = int.Parse(args[2]);

            for (int i = 1; i <= nodes; i++)
            {
                graph[i] = new HashSet<int>();
                disconnected[i] = new HashSet<int>();
            }

            for (int i = 0; i < connections; i++)
            {
                args = Console.ReadLine().Split();
                var from = int.Parse(args[0]);
                var to = int.Parse(args[1]);

                graph[from].Add(to);
                graph[to].Add(from);

                disconnected[from].Add(to);
                disconnected[to].Add(from);
            }

            Dfs(root, root, new HashSet<int>());

            var visited = new HashSet<int>();
            var max = 0;

            foreach (var node in disconnected.Keys)
            {
                if (!visited.Contains(node))
                {
                    var value = GetValue(node, visited);

                    if (value > max)
                    {
                        max = value;
                    }
                }
            }

            Console.WriteLine(max);
        }

        static int GetValue(int node, HashSet<int> visited)
        {
            visited.Add(node);
            var value = node;

            foreach (var child in disconnected[node])
            {
                if (!visited.Contains(child))
                {
                    value += GetValue(child, visited);
                }
            }

            return value;
        }

        static int Dfs(int node, int parent, HashSet<int> visited)
        {
            visited.Add(node);

            var totalNodes = 1;

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child) && child != parent)
                {
                    var subtreeNodes = Dfs(child, node, visited);

                    if (subtreeNodes % 2 == 0)
                    {
                        disconnected[node].Remove(child);
                        disconnected[child].Remove(node);
                    }

                    totalNodes += subtreeNodes;
                }
            }

            return totalNodes;
        }
    }
}
