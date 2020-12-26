using System;
using System.Collections.Generic;

namespace P03HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommand = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens.Length == 3)
                {
                    if (!guests.Contains(tokens[0]))
                    {
                        guests.Add(tokens[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[0]} is already in the list!");
                    }
                }
                else if (tokens.Length == 4)
                {
                    if (guests.Contains(tokens[0]))
                    {
                        guests.Remove(tokens[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[0]} is not in the list!");
                    }
                }
            }
            foreach (var person in guests)
            {
                Console.WriteLine(person);
            }
        }
    }
}
