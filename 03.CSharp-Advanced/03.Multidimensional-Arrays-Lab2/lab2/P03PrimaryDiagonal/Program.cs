using System;
using System.Linq;

namespace P03PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] arr = new int[size, size];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = tokens[j];
                }
            }
            int sum = 0;
            int row = 0;
            int col = 0;
            for (int k = 0; k < size; k++)
            {
                sum += arr[row, col];
                row++;
                col++;
            }
            Console.WriteLine(sum);
        }
    }
}
