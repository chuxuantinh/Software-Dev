using System;
using System.Collections.Generic;

namespace P03HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> partyList = new List<string>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();
                if (tokens[2] == "going!")
                {
                    if (partyList.Contains(tokens[0]))
                    {
                        Console.WriteLine($"{tokens[0]} is already in the list!");
                    }
                    else
                    {
                        partyList.Add(tokens[0]);
                    }
                }
                else
                {
                    if (partyList.Contains(tokens[0]))
                    {
                        partyList.Remove(tokens[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[0]} is not in the list!");
                    }
                }
            }
            foreach (var name in partyList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
