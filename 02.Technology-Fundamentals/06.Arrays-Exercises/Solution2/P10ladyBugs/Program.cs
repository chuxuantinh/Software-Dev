using System;
using System.Linq;

namespace P10ladyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] field = new int[size];
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 0 && input[i] < field.Length)
                {
                    field[input[i]] = 1;
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                
                string[] splitedCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int flyIndex = int.Parse(splitedCommand[0]);
                string direction = splitedCommand[1];
                int length = int.Parse(splitedCommand[2]);

                if (flyIndex < 0 || flyIndex >= field.Length || field[flyIndex] == 0)
                {
                    command = Console.ReadLine();
                    continue;
                }
                
                field[flyIndex] = 0;
                int position = 0;
                if (direction == "right")
                {
                    position = flyIndex + length;
                }
                else if (direction == "left")
                {
                    position = flyIndex - length;
                }
                if (position < 0 || position > field.Length - 1)
                {
                    command = Console.ReadLine();
                    continue;
                }
                while (field[position] == 1)
                {
                    flyIndex = position;
                    if (direction == "right")
                    {
                        position = flyIndex + length;
                    }
                    else if (direction == "left")
                    {
                        position = flyIndex - length;
                    }
                    if (position < 0 || position > field.Length - 1)
                    {
                        break;
                    }
                    
                }
                if (position < 0 || position > field.Length - 1)
                {
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    field[position] = 1;
                }
                

                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}
