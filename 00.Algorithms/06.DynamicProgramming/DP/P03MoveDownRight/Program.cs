using System;
using System.Collections.Generic;

namespace P03MoveDownRight
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var numbers = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    numbers[i, j] = int.Parse(line[j]);
                }
            }

            var sums = new int[rows, cols];

            sums[0, 0] = numbers[0, 0];

            for (int row = 1; row < rows; row++)
            {
                sums[row, 0] = sums[row - 1, 0] + numbers[row, 0];
            }

            for (int col = 1; col < cols; col++)
            {
                sums[0, col] = sums[0, col - 1] + numbers[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    sums[row, col] = Math.Max(sums[row - 1, col], sums[row, col - 1]) + numbers[row, col];
                }
            }

            var result = new List<string>();
            result.Add($"[{rows - 1}, {cols - 1}]");

            var currentRow = rows - 1;
            var currentCol = cols - 1;

            while (currentRow != 0 || currentCol != 0)
            {
                var top = -1;

                if (currentRow - 1 >= 0)
                {
                    top = sums[currentRow - 1, currentCol];
                }

                var left = -1;

                if (currentCol - 1 >= 0)
                {
                    left = sums[currentRow, currentCol - 1];
                }


                if (top > left)
                {
                    result.Add($"[{currentRow - 1}, {currentCol}]");
                    currentRow--;
                }
                else
                {
                    result.Add($"[{currentRow}, {currentCol - 1}]");
                    currentCol--;
                }
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
