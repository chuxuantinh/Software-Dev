namespace P01DiagonalDifference
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] matrixRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixRow[col];
                }
            }
            int i = 0;
            int j = size - 1;
            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;
            for (int k = 0; k < size; k++)
            {
                sumPrimaryDiagonal += matrix[i, i];
                sumSecondaryDiagonal += matrix[i, j];
                i++;
                j--;
            }
            int difference = Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal);
            Console.WriteLine(difference);
        }
    }
}
