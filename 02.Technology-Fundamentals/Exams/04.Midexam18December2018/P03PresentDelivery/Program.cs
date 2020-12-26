using System;
using System.Collections.Generic;
using System.Linq;

namespace P03PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@").Select(int.Parse).ToList();
            string command = Console.ReadLine();
            int currentIndex = 0;
            while (command != "Merry Xmas!")
            {
                string[] commandParts = command.Split();
                int jumpLength = int.Parse(commandParts[1]);
                currentIndex = (currentIndex + jumpLength) % houses.Count;
                
                if (houses[currentIndex] == 0)
                {
                    Console.WriteLine($"House {currentIndex} will have a Merry Christmas.");
                }
                else
                {
                    houses[currentIndex] -= 2;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Santa's last position was {currentIndex}.");
            int counter = 0;
            foreach (int house in houses)
            {
                if (house != 0)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {counter} houses.");
            }
        }
    }
}
