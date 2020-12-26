using System;
using System.Collections.Generic;

namespace P04Snakes2
{
    class Program
    {
        private static char[] currentSnake;
        private static HashSet<string> visitedCells = new HashSet<string>();
        private static HashSet<string> result = new HashSet<string>();
        private static HashSet<string> allPossibleSnakes = new HashSet<string>();

        static void GenerateSnakes(int index, int row, int col, char direction)
        {
            if (index >= currentSnake.Length)
            {
                MarkSnake();
            }
            else
            {
                var cell = $"{row} {col}";

                if (!visitedCells.Contains(cell))
                {
                    currentSnake[index] = direction;
                    visitedCells.Add(cell);
                    GenerateSnakes(index + 1, row, col + 1, 'R');
                    GenerateSnakes(index + 1, row + 1, col, 'D');
                    GenerateSnakes(index + 1, row, col - 1, 'L');
                    GenerateSnakes(index + 1, row - 1, col, 'U');
                    visitedCells.Remove(cell);
                }
            }
        }

        static void MarkSnake()
        {
            var normalSnake = new string(currentSnake);

            if (allPossibleSnakes.Contains(normalSnake))
            {
                return;
            }

            result.Add(normalSnake);

            var flippedSnake = Flip(normalSnake);
            var reversedSnake = Reverse(normalSnake);
            var reversedFlippedSnake = Flip(reversedSnake);

            for (int i = 0; i < 4; i++)
            {
                allPossibleSnakes.Add(normalSnake);
                normalSnake = Rotate(normalSnake);

                allPossibleSnakes.Add(flippedSnake);
                flippedSnake = Rotate(flippedSnake);

                allPossibleSnakes.Add(reversedSnake);
                reversedSnake = Rotate(reversedSnake);

                allPossibleSnakes.Add(reversedFlippedSnake);
                reversedFlippedSnake = Rotate(reversedFlippedSnake);
            }
        }

        private static string Rotate(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'L'; break;
                    case 'L': newSnake[i] = 'U'; break;
                    case 'U': newSnake[i] = 'R'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }

        private static string Reverse(string snake)
        {
            var newSnake = new char[snake.Length];

            newSnake[0] = 'S';

            for (int i = 1; i < snake.Length; i++)
            {
                newSnake[snake.Length - i] = snake[i];
            }

            return new string(newSnake);
        }

        private static string Flip(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'U': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'U'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            currentSnake = new char[n];

            GenerateSnakes(0, 0, 0, 'S');

            foreach (var snake in result)
            {
                Console.WriteLine(snake);
            }

            Console.WriteLine($"Snakes count = {result.Count}");
        }
    }
}
