using System;

namespace P03GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double totalSpent = 0;
            while (input != "Game Time")
            {
                double gamePrice = 0.0;
                switch (input)
                {
                    case "OutFall 4": gamePrice = 39.99; break;
                    case "CS: OG": gamePrice = 15.99; break;
                    case "Zplinter Zell": gamePrice = 19.99; break;
                    case "Honored 2": gamePrice = 59.99; break;
                    case "RoverWatch": gamePrice = 29.99; break;
                    case "RoverWatch Origins Edition": gamePrice = 39.99; break;
                    default: Console.WriteLine("Not Found"); break;
                }
                if (balance >= gamePrice && gamePrice > 0)
                {
                    Console.WriteLine($"Bought {input}");
                    balance -= gamePrice;
                    totalSpent += gamePrice;
                }
                else if (balance < gamePrice && gamePrice > 0)
                {
                    Console.WriteLine("Too Expensive");
                }
                
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                input = Console.ReadLine();
            }
            if (balance != 0)
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
