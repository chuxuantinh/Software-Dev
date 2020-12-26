using System;
using System.Linq;

class Program
{
    static int[][] field;

    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        field = new int[size][];
        ReadField();
        string[] coords = Console.ReadLine()
            .Split();

        foreach (var coord in coords)
        {
            int[] coordArgs = coord
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            int row = coordArgs[0];
            int col = coordArgs[1];
            BombCells(row, col);
        }

        PrintCellInfo();
        PrintField();
    }

    private static void BombCells(int row, int col)
    {
        int damage = field[row][col];

        if (damage > 0)
        {
            BombCell(row - 1, col - 1, damage);
            BombCell(row - 1, col, damage);
            BombCell(row - 1, col + 1, damage);
            BombCell(row, col - 1, damage);
            BombCell(row, col + 1, damage);
            BombCell(row + 1, col - 1, damage);
            BombCell(row + 1, col, damage);
            BombCell(row + 1, col + 1, damage);
            field[row][col] = 0;
        }
    }

    private static void BombCell(int row, int col, int damage)
    {
        if (row >= 0 && row < field.Length &&
            col >= 0 && col < field.Length &&
            field[row][col] > 0)
        {
            field[row][col] -= damage;
        }
    }

    static void ReadField()
    {
        for (int i = 0; i < field.Length; i++)
        {
            int[] row = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            field[i] = row;
        }
    }

    static void PrintField()
    {
        for (int row = 0; row < field.Length; row++)
        {
            Console.WriteLine(string.Join(" ", field[row]));
        }
    }

    static void PrintCellInfo()
    {
        int aliveCellsCount = 0;
        int aliveCellsSum = 0;

        for (int row = 0; row < field.Length; row++)
        {
            int[] aliveCells = field[row]
                .Where(x => x > 0)
                .ToArray();
            aliveCellsCount += aliveCells.Length;
            aliveCellsSum += aliveCells.Sum();
        }

        Console.WriteLine($"Alive cells: {aliveCellsCount}");
        Console.WriteLine($"Sum: {aliveCellsSum}");
    }
}