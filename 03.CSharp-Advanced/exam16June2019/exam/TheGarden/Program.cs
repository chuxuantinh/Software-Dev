using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] jaggedArray = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                char[] chars = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                jaggedArray[i] = chars;
            }
            int carrots = 0;
            int potatoes = 0;
            int lettuce = 0;
            int harmedVegetables = 0;
            string command = Console.ReadLine();
            while (command != "End of Harvest")
            {
                int row = 0;
                int col = 0;
                string operation = string.Empty;
                string direction = string.Empty;
                string[] tokens = command.Split();
                if (tokens.Length == 3)
                {
                    operation = tokens[0];
                    row = int.Parse(tokens[1]);
                    col = int.Parse(tokens[2]);
                }
                else if (tokens.Length == 4)
                {
                    operation = tokens[0];
                    row = int.Parse(tokens[1]);
                    col = int.Parse(tokens[2]);
                    direction = tokens[3];
                }
                
                if (operation == "Harvest")
                {
                    if (row < 0
                    || row >= rows
                    || col < 0
                    || col >= jaggedArray[row].Length)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    if (jaggedArray[row][col] == ' ')
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        switch (jaggedArray[row][col])
                        {
                            case 'C':
                                jaggedArray[row][col] = ' ';
                                carrots++;
                                break;
                            case 'P':
                                jaggedArray[row][col] = ' ';
                                potatoes++;
                                break;
                            case 'L':
                                jaggedArray[row][col] = ' ';
                                lettuce++;
                                break;
                        }
                    }
                }
                else if (operation == "Mole")
                {
                    if (row < 0
                    || row >= rows
                    || col < 0
                    || col >= jaggedArray[row].Length)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    while (row >= 0
                    && row < rows
                    && col >= 0
                    && col < jaggedArray[row].Length)
                    {
                        switch (jaggedArray[row][col])
                        {
                            case 'C':
                                jaggedArray[row][col] = ' ';
                                harmedVegetables++;
                                break;
                            case 'P':
                                jaggedArray[row][col] = ' ';
                                harmedVegetables++;
                                break;
                            case 'L':
                                jaggedArray[row][col] = ' ';
                                harmedVegetables++;
                                break;
                            case ' ':
                                break;
                        }
                        switch (direction)
                        {
                            case "up":
                                row -= 2;
                                break;
                            case "down":
                                row += 2;
                                break;
                            case "left":
                                col -= 2;
                                break;
                            case "right":
                                col += 2;
                                break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            Console.WriteLine($"Carrots: {carrots}");
            Console.WriteLine($"Potatoes: {potatoes}");
            Console.WriteLine($"Lettuce: {lettuce}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }
    }
}
