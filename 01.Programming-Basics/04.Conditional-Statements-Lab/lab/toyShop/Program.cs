using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceExcursion = double.Parse(Console.ReadLine());
            int amountPuzzels = int.Parse(Console.ReadLine());
            int amountDolls = int.Parse(Console.ReadLine());
            int amountBears = int.Parse(Console.ReadLine());
            int amountMinions = int.Parse(Console.ReadLine());
            int amountTrucks = int.Parse(Console.ReadLine());
            double sum = amountPuzzels * 2.60 + amountDolls * 3 + amountBears * 4.10 + amountMinions * 8.20 + amountTrucks * 2;
            int numberOfToys = amountPuzzels + amountDolls + amountBears + amountMinions + amountTrucks;
            if (numberOfToys >= 50)
            {
                sum *= 0.75;
            }
            sum *= 0.9;
            if (sum >= priceExcursion)
            {
                Console.WriteLine($"Yes! {(sum - priceExcursion):f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(priceExcursion - sum):f2} lv needed.");
            }
        }
    }
}
