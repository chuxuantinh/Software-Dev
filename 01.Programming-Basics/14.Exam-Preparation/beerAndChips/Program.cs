using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beersCount = int.Parse(Console.ReadLine());
            int chipsCount = int.Parse(Console.ReadLine());
            double totalBeerPrice = beersCount * 1.2;
            double chipsPrice = totalBeerPrice * 0.45;
            double totalChipsPrice = Math.Ceiling(chipsPrice * chipsCount);
            double totalMoneySpent = totalBeerPrice + totalChipsPrice;
            if (budget >= totalMoneySpent)
            {
                double moneyLeft = budget - totalMoneySpent;
                Console.WriteLine($"{name} bought a snack and has {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyShort = totalMoneySpent - budget;
                Console.WriteLine($"{name} needs {moneyShort:f2} more leva!");
            }
        }
    }
}
