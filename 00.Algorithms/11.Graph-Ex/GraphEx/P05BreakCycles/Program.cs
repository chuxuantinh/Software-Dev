using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace P05BreakCycles
{
    class Program
    {
        static SortedDictionary<char, List<char>> graph; 

        static void Main(string[] args)
        {
            graph = new SortedDictionary<char, List<char>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var edgeParts = line.Split();
                var node = edgeParts[0][0];
                var otherNodes = edgeParts.Skip(2).ToArray();

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<char>();
                }

                graph[node].AddRange(otherNodes.Select(node => node[0]));
            }

            var result = new List<string>();

            foreach (var nodeKvp in graph)
            {
                var start = nodeKvp.Key;

                foreach (var end in graph[start].OrderBy(e => e))
                {
                    graph[start].Remove(end);
                    graph[end].Remove(start);

                    if (HasPath(start, end))
                    {
                        result.Add($"{start} - {end}");
                    }
                    else
                    {
                        graph[start].Add(end);
                        graph[end].Add(start);
                    }
                }
            }

            Console.WriteLine($"Edges to remove: {result.Count}");
            result.ForEach(Console.WriteLine);
        }

        public static bool HasPath(char start, char end)
        {
            var queue = new Queue<char>();

            var visited = new HashSet<char>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);

                        if (child == end)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
