using System;
using System.Collections.Generic;

namespace _03.Shortest_Path
{
    internal class Program
    {
        private static readonly List<string> Paths = new List<string>();
        private static readonly List<int> UnknownIndexes = new List<int>();
        private static readonly char[] Directions = { 'L', 'R', 'S' };

        private static void Main()
        {
            var directions = Console.ReadLine()
                .ToCharArray();

            for (var i = 0; i < directions.Length; i++)
            {
                if (directions[i].Equals('*'))
                {
                    UnknownIndexes.Add(i);
                }
            }

            GetPossiblePaths(directions, 0);

            Console.WriteLine(Paths.Count);

            Console.WriteLine(string.Join(Environment.NewLine, Paths));
        }

        private static void GetPossiblePaths(char[] directions, int unknownIndex)
        {
            if (unknownIndex == UnknownIndexes.Count)
            {
                Paths.Add(string.Concat(directions));
                return;
            }

            var index = UnknownIndexes[unknownIndex];

            foreach (var direction in Directions)
            {
                directions[index] = direction;
                GetPossiblePaths(directions, unknownIndex + 1);
            }
        }
    }
}