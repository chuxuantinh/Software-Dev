using System;
using System.Collections.Generic;
using System.Linq;

namespace P02Sort
{
    class Program
    {
        static List<int>[] graph;
        static HashSet<int> GetNodesWithIncommingEdges()
        {
            var nodesWithIncommingEdges = new HashSet<int>();

            graph.SelectMany(s => s).ToList().ForEach(e => nodesWithIncommingEdges.Add(e));

            return nodesWithIncommingEdges;
        }

        static void Main(string[] args)
        {
            graph = new List<int>[]
            {
                new List<int> { 1, 2 },
                new List<int> { 3, 4 },
                new List<int> { 5 },
                new List<int> { 2, 5 },
                new List<int> { 3 },
                new List<int> { },
            };

            var result = new List<int>();
            var nodes = new HashSet<int>();

            var nodesWithIncommingEdges = GetNodesWithIncommingEdges();

            for (int i = 0; i < graph.Length; i++)
            {
                if (!nodesWithIncommingEdges.Contains(i))
                {
                    nodes.Add(i);
                }
            }

            while (nodes.Count != 0)
            {
                var currentNode = nodes.First();
                nodes.Remove(currentNode);

                result.Add(currentNode);

                var children = graph[currentNode].ToList();
                graph[currentNode] = new List<int>();

                var leftNodesWithIncommingEdges = GetNodesWithIncommingEdges();

                foreach (var child in children)
                {
                    if (!leftNodesWithIncommingEdges.Contains(child))
                    {
                        nodes.Add(child);
                    }
                }
            }

            if (graph.SelectMany(s => s).Any())
            {
                Console.WriteLine("Sorry!");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
