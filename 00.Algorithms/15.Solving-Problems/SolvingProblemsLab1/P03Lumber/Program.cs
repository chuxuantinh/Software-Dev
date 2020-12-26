using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Lumber
{
    internal class Program
    {
        private static int _count;

        private static void Main()
        {
            var tokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var logsCount = tokens[0];
            var queries = tokens[1];

            var logs = new List<Log>();

            var graph = new List<int>[logsCount + 1];

            for (var i = 1; i <= logsCount; i++)
            {
                var currentLog = new Log(Console.ReadLine(), i);

                graph[i] = new List<int>();

                foreach (var log in logs)
                {
                    if (!log.Overlap(currentLog))
                    {
                        continue;
                    }

                    graph[log.Index].Add(i);
                    graph[i].Add(log.Index);
                }

                logs.Add(currentLog);
            }

            var visited = new bool[logsCount + 1];
            var id = new int[logsCount + 1];

            for (var i = 1; i <= logsCount; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                DFS(i, visited, id, graph);
                _count++;
            }

            var sb = new StringBuilder();

            for (var i = 0; i < queries; i++)
            {
                var query = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                sb.AppendLine(id[query[0]] == id[query[1]] ? "YES" : "NO");
            }

            Console.Write(sb.ToString());
        }

        private static void DFS(int i, bool[] visited, IList<int> id, List<int>[] graph)
        {
            visited[i] = true;
            id[i] = _count;

            foreach (var child in graph[i])
            {
                if (!visited[child])
                {
                    DFS(child, visited, id, graph);
                }
            }
        }

        private class Log
        {
            public int Index { get; }
            private readonly int _x1;
            private readonly int _y1;
            private readonly int _x2;
            private readonly int _y2;

            public Log(string coordinatesStr, int index)
            {
                var coordinates = coordinatesStr
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                _x1 = Math.Min(coordinates[0], coordinates[2]);
                _y1 = Math.Max(coordinates[1], coordinates[3]);
                _x2 = Math.Max(coordinates[0], coordinates[2]);
                _y2 = Math.Min(coordinates[1], coordinates[3]);

                Index = index;
            }

            public bool Overlap(Log other)
            {
                return _x1 <= other._x2 && other._x1 <= _x2 &&
                       _y1 >= other._y2 && other._y1 >= _y2;
            }

            public override string ToString()
            {
                return $"{Index}: {_x1} {_y1}, {_x2} {_y2}";
            }
        }
    }
}
