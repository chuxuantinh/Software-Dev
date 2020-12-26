using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P01CableNetwork
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Cost { get; set; }
    }

    class Program
    {
        static Dictionary<int, List<Edge>> graph;
        
        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine().Split()[1]);
            var pathParts = Console.ReadLine().Split();
            var start = int.Parse(pathParts[1]);
            var end = int.Parse(pathParts[3]);
            var edges = int.Parse(Console.ReadLine().Split()[1]);

            graph = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < edges; i++)
            {
                var edgeParts = Console.ReadLine().Split();

                var edge = new Edge
                {
                    First = int.Parse(edgeParts[0]),
                    Second = int.Parse(edgeParts[1]),
                    Cost = int.Parse(edgeParts[2]),
                };

                if (!graph.ContainsKey(edge.First))
                {
                    graph[edge.First] = new List<Edge>();
                }

                if (!graph.ContainsKey(edge.Second))
                {
                    graph[edge.Second] = new List<Edge>();
                }

                graph[edge.First].Add(edge);
                graph[edge.Second].Add(edge);
            }

            var percentages = Enumerable.Repeat<double>(-1, graph.Count).ToArray();
            percentages[start] = 100;

            var visited = new bool[graph.Count];
            visited[start] = true;

            var prev = new int[graph.Count];
            prev[start] = -1;

            var queue = new OrderedBag<int>(Comparer<int>.Create((a, b) => (int)(percentages[b] - percentages[a])));

            queue.Add(start);

            while (queue.Count > 0)
            {
                var max = queue.RemoveFirst();

                if (percentages[max] == -1)
                {
                    break;
                }

                foreach (var child in graph[max])
                {
                    var otherNode = child.First == max ? child.Second : child.First;

                    if (!visited[otherNode])
                    {
                        visited[otherNode] = true;
                        queue.Add(otherNode);
                    }

                    var newPerc = percentages[max] / 100 * child.Cost;

                    if (percentages[otherNode] < newPerc)
                    {
                        percentages[otherNode] = newPerc;
                        prev[otherNode] = max;
                        queue = new OrderedBag<int>(queue, Comparer<int>.Create((a, b) => (int)(percentages[b] - percentages[a])));
                    }
                }
            }

            var result = new List<int>();

            var current = end;

            while (current != -1)
            {
                result.Add(current);

                current = prev[current];
            }

            result.Reverse();

            Console.WriteLine($"Most reliable path reliability: {percentages[end]:f2}%");

            Console.WriteLine(string.Join(" -> ", result));
        }
    }
}
