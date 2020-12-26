using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Engine
    {
        private char[][] room;
        private int[] playerPosition;
        private int[] enemyPosition;

        public Engine()
        {
            playerPosition = new int[2];
            enemyPosition = new int[2];
        }

        public void Run()
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            int enemyRow = enemyPosition[0];
            int enemyCol = enemyPosition[1];
            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];

            InitializeMatrixAndFindSamPosition(numberOfRows, ref playerRow, ref playerCol);

            var playerMoves = Console.ReadLine().ToCharArray();
            
            for (int i = 0; i < playerMoves.Length; i++)
            {
                MoveEnemy();

                FindEnemyNewPosition(ref enemyRow, ref enemyCol, playerRow);

                if (EnemySeePlayer(enemyRow, enemyCol, playerRow, playerCol))
                {
                    PrintPlayerDiedOutput(playerRow, playerCol);
                    Exit();
                }

                MovePlayer(playerMoves, i, ref playerRow, ref playerCol);

                FindEnemyNewPosition(ref enemyRow, ref enemyCol, playerRow);

                if (PlayerReachedNikoladze(enemyRow, enemyCol, playerRow))
                {
                    PrintNikoladzeKilledOutput(enemyRow, enemyCol);
                    Exit();
                }
            }
        }

        private void PrintNikoladzeKilledOutput(int enemyRow, int enemyCol)
        {
            room[enemyRow][enemyCol] = 'X';
            Console.WriteLine("Nikoladze killed!");

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }

        private bool PlayerReachedNikoladze(int enemyRow, int enemyCol, int playerRow)
        {
            return room[enemyRow][enemyCol] == 'N' && playerRow == enemyRow;
        }

        private void MovePlayer(char[] playerMoves, int i, ref int playerRow, ref int playerCol)
        {
            room[playerRow][playerCol] = '.';

            switch (playerMoves[i])
            {
                case 'U':
                    playerRow--;
                    break;
                case 'D':
                    playerRow++;
                    break;
                case 'L':
                    playerCol--;
                    break;
                case 'R':
                    playerCol++;
                    break;
                default:
                    break;
            }

            room[playerRow][playerCol] = 'S';
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private void PrintPlayerDiedOutput(int playerRow, int playerCol)
        {
            room[playerRow][playerCol] = 'X';
            Console.WriteLine($"Sam died at {playerRow}, {playerCol}");

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }

        private void FindEnemyNewPosition(ref int enemyRow, ref int enemyCol, int playerRow)
        {
            for (int j = 0; j < room[playerRow].Length; j++)
            {
                if (room[playerRow][j] != '.' && room[playerRow][j] != 'S')
                {
                    enemyRow = playerRow;
                    enemyCol = j;
                }
            }
        }

        private bool EnemySeePlayer(int enemyRow, int enemyCol, int playerRow, int playerCol)
        {
            return (playerCol < enemyCol && room[enemyRow][enemyCol] == 'd' && enemyRow == playerRow)
                || (enemyCol < playerCol && room[enemyRow][enemyCol] == 'b' && enemyRow == playerRow);
        }

        private void MoveEnemy()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private void InitializeMatrixAndFindSamPosition(int numberOfRows, ref int playerRow, ref int playerCol)
        {
            room = new char[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                    if (room[row][col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
