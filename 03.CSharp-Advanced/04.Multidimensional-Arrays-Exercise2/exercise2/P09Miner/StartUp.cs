namespace P09Miner
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static int size;
        static int playerRow;
        static int playerCol;
        public static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] inputRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }
            
            int coalsCount = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }
            int collectedCoals = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up" || commands[i] == "down")
                {
                    playerRow += MovePlayer(commands[i], playerRow, playerCol);
                }
                else if (commands[i] == "left" || commands[i] == "right")
                {
                    playerCol += MovePlayer(commands[i], playerRow, playerCol);
                }
               
                if (matrix[playerRow, playerCol] == 'c')
                {
                    collectedCoals++;
                    matrix[playerRow, playerCol] = '*';
                    if (collectedCoals == coalsCount)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        return;
                    }
                }
                else if (matrix[playerRow, playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    return;
                }
            }
            Console.WriteLine($"{coalsCount - collectedCoals} coals left. ({playerRow}, {playerCol})");
        }

        private static int MovePlayer(string direction, int playerRow, int playerCol)
        {
            if (direction == "up" && playerRow - 1 >= 0)
            {
                return -1;
            }
            else if (direction == "down" && playerRow + 1 < size)
            {
                return +1;
            }
            else if (direction == "left" && playerCol - 1 >= 0)
            {
                return -1;
            }
            else if (direction == "right" && playerCol + 1 < size)
            {
                return +1;
            }
            else
            {
                return 0;
            }
        }
    }
}
