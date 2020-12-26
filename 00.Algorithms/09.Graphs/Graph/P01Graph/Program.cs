using System;
using System.Collections.Generic;

namespace P01Graph
{
    class Program
    {
        static List<int>[] graph;

        static bool[] visited;

        static void Dfs(int n)
        {
            if (!visited[n])
            {
                visited[n] = true;

                foreach (var child in graph[n])
                {
                    Dfs(child);
                }

                Console.Write($"{n} ");
            }
        }

        static void Bfs(int n)
        {
            if (visited[n])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(n);
            visited[n] = true;

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                Console.Write($"{currentNode} ");

                foreach (var child in graph[currentNode])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            graph = new List<int>[]
            {
                new List<int> { 3, 6},
                new List<int> { 2, 3, 4, 5, 6},
                new List<int> { 1, 4, 5},
                new List<int> { 0, 1, 5},
                new List<int> { 1, 2, 6},
                new List<int> { 1, 2, 3},
                new List<int> { 0, 1, 4},
                new List<int> { 8 },
                new List<int> { 7 },
            };

            visited = new bool[graph.Length];

            var components = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    components++;
                    Console.Write($"Connected component {components}: ");
                    Dfs(i); //Bfs(i);
                    Console.WriteLine();
                }
                
            }
        }
    }
}
