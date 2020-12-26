using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Towns
{
    internal class Program
    {
        private static void Main()
        {
            var townsCount = int.Parse(Console.ReadLine());

            var townsPopulation = new int[townsCount];

            for (var i = 0; i < townsCount; i++)
            {
                townsPopulation[i] = int.Parse(Console.ReadLine().Split()[0]);
            }

            var lis = Lis(townsPopulation);

            var lds = Lis(townsPopulation.Reverse().ToArray())
                .Reverse()
                .ToArray();

            var bestLength = 0;

            for (var i = 0; i < townsCount; i++)
            {
                var currentLength = lis[i] + lds[i] - 1;

                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                }
            }

            Console.WriteLine(bestLength);
        }

        private static int[] Lis(IReadOnlyList<int> townsPopulation)
        {
            var lis = new int[townsPopulation.Count];

            for (var i = 0; i < lis.Length; i++)
            {
                lis[i] = 1;
            }

            for (var i = 0; i < townsPopulation.Count; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (townsPopulation[j] < townsPopulation[i])
                    {
                        lis[i] = Math.Max(lis[i], lis[j] + 1);
                    }
                }
            }

            return lis;
        }
    }
}