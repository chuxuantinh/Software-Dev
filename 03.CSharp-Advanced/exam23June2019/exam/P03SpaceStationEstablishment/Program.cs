using System;

namespace P03SpaceStationEstablishment
{
    class Program
    {
        static char[][] galaxy;
        static int playerRow;
        static int playerCol;
        static int firstBlackHoleRow = -1;
        static int firstBlackHoleCol = -1;
        static int secondBlackHoleRow = -1;
        static int secondBlackHoleCol = -1;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            galaxy = new char[rows][];

            for (int row = 0; row < galaxy.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                galaxy[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    galaxy[row][col] = input[col];

                    if (galaxy[row][col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if (galaxy[row][col] == 'O' && firstBlackHoleRow == -1)
                    {
                        firstBlackHoleRow = row;
                        firstBlackHoleCol = col;
                    }
                    else if (galaxy[row][col] == 'O' && firstBlackHoleRow != -1)
                    {
                        secondBlackHoleRow = row;
                        secondBlackHoleCol = col;
                    }
                }
            }

            int energy = 0;
            bool isInTheVoid = false;
            while (true)
            {
                if (energy >= 50)
                {
                    End(isInTheVoid, energy);
                }
                string direction = Console.ReadLine();
                if (direction == "down")
                {
                    galaxy[playerRow][playerCol] = '-';
                    playerRow++;
                    if (playerRow == galaxy.Length)
                    {
                        isInTheVoid = true;
                        End(isInTheVoid, energy);
                    }
                }
                else if (direction == "up")
                {
                    galaxy[playerRow][playerCol] = '-';
                    playerRow--;
                    if (playerRow < 0)
                    {
                        isInTheVoid = true;
                        End(isInTheVoid, energy);
                    }
                }
                else if (direction == "left")
                {
                    galaxy[playerRow][playerCol] = '-';
                    playerCol--;
                    if (playerCol < 0)
                    {
                        isInTheVoid = true;
                        End(isInTheVoid, energy);
                    }
                }
                else if (direction == "right")
                {
                    galaxy[playerRow][playerCol] = '-';
                    playerCol++;
                    if (playerCol == galaxy[playerRow].Length)
                    {
                        isInTheVoid = true;
                        End(isInTheVoid, energy);
                    }
                }
                if (char.IsDigit(galaxy[playerRow][playerCol]))
                {
                    energy += int.Parse(galaxy[playerRow][playerCol].ToString());
                    galaxy[playerRow][playerCol] = 'S';
                }
                else if (galaxy[playerRow][playerCol] == 'O')
                {
                    if (playerRow == firstBlackHoleRow && playerCol == firstBlackHoleCol)
                    {
                        galaxy[playerRow][playerCol] = '-';
                        playerRow = secondBlackHoleRow;
                        playerCol = secondBlackHoleCol;
                        galaxy[playerRow][playerCol] = 'S';
                    }
                    else if (playerRow == secondBlackHoleRow && playerCol == secondBlackHoleCol)
                    {
                        galaxy[playerRow][playerCol] = '-';
                        playerRow = firstBlackHoleRow;
                        playerCol = firstBlackHoleCol;
                        galaxy[playerRow][playerCol] = 'S';
                    }
                }
                else if (galaxy[playerRow][playerCol] == '-')
                {
                    galaxy[playerRow][playerCol] = 'S';
                }
                
            }
        }

        private static void End(bool isInTheVoid, int energy)
        {
            if (isInTheVoid)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            Console.WriteLine($"Star power collected: {energy}");
            for (int row = 0; row < galaxy.Length; row++)
            {
                for (int col = 0; col < galaxy[row].Length; col++)
                {
                    Console.Write(galaxy[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
    }
}
