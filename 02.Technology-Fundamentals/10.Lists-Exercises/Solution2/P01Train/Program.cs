using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "Add")
                {
                    int numberToAdd = int.Parse(tokens[1]);
                    train.Add(numberToAdd);
                }
                else
                {
                    for (int i = 0; i < train.Count; i++)
                    {
                        int passengersToAdd = int.Parse(tokens[0]);
                        if (train[i] + passengersToAdd <= capacity)
                        {
                            train[i] += passengersToAdd;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", train));
        }
    }
}
