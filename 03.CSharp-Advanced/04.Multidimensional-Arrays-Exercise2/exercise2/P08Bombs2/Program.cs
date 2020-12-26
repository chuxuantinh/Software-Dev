using System;
using System.Linq;

class Bombs
{
    static int[,] matrix;

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int j = 0; j < row.Length; j++)
            {
                matrix[i, j] = row[j];
            }
        }

        string[] coordinates = Console.ReadLine().Split(' ');

        if (size > 1)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] coordinate = coordinates[i].Split(',');
                int row = int.Parse(coordinate[0]);
                int column = int.Parse(coordinate[1]);

                if (row == 0)
                {
                    if (column == 0)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row + 1, column + 1);
                            ChangeCell(row, column, row + 1, column);
                            matrix[row, column] = 0;
                        }
                    }
                    else if (column == size - 1)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row + 1, column);
                            ChangeCell(row, column, row + 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                    else
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row + 1, column + 1);
                            ChangeCell(row, column, row + 1, column);
                            ChangeCell(row, column, row + 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                }
                else if (row == size - 1)
                {
                    if (column == 0)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column + 1);
                            ChangeCell(row, column, row, column + 1);
                            matrix[row, column] = 0;
                        }
                    }
                    else if (column == size - 1)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                    else
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column + 1);
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row, column - 1);
                            ChangeCell(row, column, row - 1, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                }
                else
                {
                    if (column == 0)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column + 1);
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row + 1, column + 1);
                            ChangeCell(row, column, row + 1, column);
                            matrix[row, column] = 0;
                        }
                    }
                    else if (column == size - 1)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            ChangeCell(row, column, row + 1, column - 1);
                            ChangeCell(row, column, row + 1, column);
                            matrix[row, column] = 0;
                        }
                    }
                    else
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column + 1);
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row + 1, column + 1);
                            ChangeCell(row, column, row + 1, column);
                            ChangeCell(row, column, row + 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            ChangeCell(row, column, row - 1, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                }
            }
        }

        int cellsAliveCount = 0;
        int cellsAliveSum = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (matrix[i, j] > 0)
                {
                    cellsAliveCount++;
                    cellsAliveSum += matrix[i, j];
                }
            }
        }

        Console.WriteLine($"Alive cells: {cellsAliveCount}");
        Console.WriteLine($"Sum: {cellsAliveSum}");

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }

            Console.WriteLine();
        }
    }

    static void ChangeCell(int bombRow, int bombColumn, int row, int column)
    {
        if (matrix[row, column] > 0)
        {
            matrix[row, column] -= matrix[bombRow, bombColumn];
        }
    }
}