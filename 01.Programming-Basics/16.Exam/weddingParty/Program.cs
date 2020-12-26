using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weddingParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberGuests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            int priceCuvert = 20 * numberGuests;
            if (priceCuvert <= budget)
            {
                int moneyLeft = budget - priceCuvert;
                double moneyFireworks = 0.4 * moneyLeft;
                double moneyDonation = moneyLeft - moneyFireworks;
                Console.WriteLine($"Yes! {moneyFireworks:f0} lv are for fireworks and {moneyDonation:f0} lv are for donation.");
            }
            else
            {
                int moneyShort = priceCuvert - budget;
                Console.WriteLine($"They won't have enough money to pay the covert. They will need {moneyShort:f0} lv more.");
            }
        }
    }
}
