using System;
using System.Collections.Generic;

namespace P02LCS
{
    class Program
    {
        static int[,] lcs;
        static string first;
        static string second;

        static void Main(string[] args)
        {
            first = Console.ReadLine();
            second = Console.ReadLine();

            lcs = new int[first.Length + 1, second.Length + 1];

            for (int row = 1; row <= first.Length; row++)
            {
                for (int col = 1; col <= second.Length; col++)
                {
                    var up = lcs[row - 1, col];
                    var left = lcs[row, col - 1];

                    var result = Math.Max(up, left);

                    if (first[row - 1] == second[col - 1])
                    {
                        result = Math.Max(1 + lcs[row - 1, col - 1], result);
                    }

                    lcs[row, col] = result;
                }
            }

            Console.WriteLine(lcs[first.Length, second.Length]);

            var currentRow = first.Length;
            var currentCol = second.Length;
            var endResult = new List<char>();

            while (currentRow > 0 && currentCol > 0)
            {
                if (first[currentRow - 1] == second[currentCol - 1] &&
                    lcs[currentRow, currentCol] - 1 == lcs[currentRow - 1, currentCol - 1]) 
                {
                    endResult.Add(first[currentRow - 1]);
                    
                    currentRow--;
                    currentCol--;
                }
                else if (lcs[currentRow - 1, currentCol] == lcs[currentRow, currentCol])
                {
                    currentRow--;
                }
                else
                {
                    currentCol--;
                }
            }
        }
    }
}
