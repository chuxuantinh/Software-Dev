namespace P04MatrixShuffling
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] matrixRows = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixRows[col];
                }
            }
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0]?.ToLower() != "end")
            {
                if (command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (command[0] != "swap" || int.Parse(command[1]) < 0 || int.Parse(command[1]) >= matrix.GetLength(0) 
                                              || int.Parse(command[2]) < 0 || int.Parse(command[2]) >= matrix.GetLength(1)
                                              || int.Parse(command[3]) < 0 || int.Parse(command[3]) >= matrix.GetLength(0)
                                              || int.Parse(command[4]) < 0 || int.Parse(command[4]) >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string temp = matrix[int.Parse(command[1]), int.Parse(command[2])];
                    matrix[int.Parse(command[1]), int.Parse(command[2])] = matrix[int.Parse(command[3]), int.Parse(command[4])];
                    matrix[int.Parse(command[3]), int.Parse(command[4])] = temp;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
