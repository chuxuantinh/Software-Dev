using System;

namespace P02TronRacers
{
    class Program
    {
        static char[,] battlefield;
        static int firstPlayerRow;
        static int firstPlayerCol;

        static int secondPlayerRow;
        static int secondPlayerCol;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            battlefield = new char[rows,rows];
            Initialize();

            while (true)
            {
                string[] directions = Console.ReadLine().Split();
                string firstPlayerDirection = directions[0];
                string secondPlayerDirection = directions[1];

                if (firstPlayerDirection == "down")
                {
                    firstPlayerRow++;
                    if (firstPlayerRow == battlefield.GetLength(0))
                    {
                        firstPlayerRow = 0;
                    }
                }
                else if (firstPlayerDirection == "up")
                {
                    firstPlayerRow--;
                    if (firstPlayerRow < 0)
                    {
                        firstPlayerRow = battlefield.GetLength(0) - 1;
                    }
                }
                else if (firstPlayerDirection == "left")
                {
                    firstPlayerCol--;
                    if (firstPlayerCol < 0)
                    {
                        firstPlayerCol = battlefield.GetLength(1) - 1;
                    }
                }
                else if (firstPlayerDirection == "right")
                {
                    firstPlayerCol++;
                    if (firstPlayerCol == battlefield.GetLength(1))
                    {
                        firstPlayerCol = 0;
                    }
                }
                if (battlefield[firstPlayerRow,firstPlayerCol] == 's')
                {
                    battlefield[firstPlayerRow,firstPlayerCol] = 'x';
                    End();
                }
                else
                {
                    battlefield[firstPlayerRow,firstPlayerCol] = 'f';
                }

                if (secondPlayerDirection == "down")
                {
                    secondPlayerRow++;
                    if (secondPlayerRow == battlefield.GetLength(0))
                    {
                        secondPlayerRow = 0;
                    }
                }
                else if (secondPlayerDirection == "up")
                {
                    secondPlayerRow--;
                    if (secondPlayerRow < 0)
                    {
                        secondPlayerRow = battlefield.GetLength(0) - 1;
                    }
                }
                else if (secondPlayerDirection == "left")
                {
                    secondPlayerCol--;
                    if (secondPlayerCol < 0)
                    {
                        secondPlayerCol = battlefield.GetLength(1) - 1;
                    }
                }
                else if (secondPlayerDirection == "right")
                {
                    secondPlayerCol++;
                    if (secondPlayerCol == battlefield.GetLength(1))
                    {
                        secondPlayerCol = 0;
                    }
                }
                if (battlefield[secondPlayerRow,secondPlayerCol] == 'f')
                {
                    battlefield[secondPlayerRow,secondPlayerCol] = 'x';
                    End();
                }
                else
                {
                    battlefield[secondPlayerRow,secondPlayerCol] = 's';
                }
            }
        }

        private static void End()
        {
            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    Console.Write(battlefield[row,col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void Initialize()
        {
            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
               
                for (int col = 0; col < input.Length; col++)
                {
                    battlefield[row,col] = input[col];

                    if (battlefield[row,col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (battlefield[row,col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
        }
    }
}
