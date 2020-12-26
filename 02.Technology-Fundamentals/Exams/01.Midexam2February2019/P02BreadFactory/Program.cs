using System;
using System.Linq;

namespace P02BreadFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = 100;
            int initialCoins = 100;
            string[] days = Console.ReadLine().Split("|").ToArray();
            for (int day = 0; day < days.Length; day++)
            {
                string[] @event = days[day].Split("-");
                string command = @event[0];
                int number = int.Parse(@event[1]);
                if (command == "rest")
                {
                    int currentEnergy = initialEnergy;
                    initialEnergy += number;
                    if (initialEnergy > 100)
                    {
                        Console.WriteLine($"You gained {100 - currentEnergy} energy.");
                        Console.WriteLine($"Current energy: 100.");
                        initialEnergy = 100;
                    }
                    else
                    {
                        Console.WriteLine($"You gained {number} energy.");
                        Console.WriteLine($"Current energy: {initialEnergy}.");
                    }
                }
                else if (command == "order")
                {
                    int currentEnergy = initialEnergy;
                    if (currentEnergy - 30 >= 0)
                    {
                        Console.WriteLine($"You earned {number} coins.");
                        initialCoins += number;
                        initialEnergy -= 30;
                    }
                    else
                    {
                        Console.WriteLine("You had to rest!");
                        initialEnergy += 50;
                        if (initialEnergy > 100)
                        {
                            
                            initialEnergy = 100;
                        }
                        
                    }
                }
                else
                {
                    if (initialCoins - number > 0)
                    {
                        Console.WriteLine($"You bought {command}.");
                        initialCoins -= number;
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {command}.");
                        return;
                    }
                }
            }
            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {initialCoins}");
            Console.WriteLine($"Energy: {initialEnergy}");
        }
    }
}
