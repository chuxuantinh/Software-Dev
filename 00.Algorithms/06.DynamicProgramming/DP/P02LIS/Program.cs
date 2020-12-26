using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int[] numbers;

    static void Main(string[] args)
    {
        numbers = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

        var solutions = new int[numbers.Length];
        var prev = new int[numbers.Length];

        var maxSolution = 0;
        var maxSolutionIndex = 0;

        for (int current = 0; current < numbers.Length; current++)
        {
            var solution = 1;
            var prevIndex = -1;
            var currentNumber = numbers[current];

            for (int solIndex = 0; solIndex < current; solIndex++)
            {
                var prevNumber = numbers[solIndex];
                var prevSolution = solutions[solIndex];

                if (currentNumber > prevNumber && solution <= prevSolution)
                {
                    solution = prevSolution + 1;
                    prevIndex = solIndex;
                }
            }

            solutions[current] = solution;
            prev[current] = prevIndex;

            if (solution > maxSolution)
            {
                maxSolution = solution;
                maxSolutionIndex = current;
            }
        }

        var index = maxSolutionIndex;
        var result = new List<int>();

        while (index != -1)
        {
            var currentNumber = numbers[index];
            result.Add(currentNumber);
            index = prev[index];
        }

        result.Reverse();

        Console.WriteLine(string.Join(" ", result));
    }
}
