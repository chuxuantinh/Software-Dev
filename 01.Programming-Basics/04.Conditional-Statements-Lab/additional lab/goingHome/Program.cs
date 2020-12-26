using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goingHome
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceKm = int.Parse(Console.ReadLine());
            int fuelConsumption = int.Parse(Console.ReadLine());
            double fuelPrice = double.Parse(Console.ReadLine());
            int tornamentPrice = int.Parse(Console.ReadLine());

            double fuelConsumptionInL = (distanceKm * fuelConsumption) / 100.0;
            double totalPrice = fuelConsumptionInL * fuelPrice;

            double moneyLeft = tornamentPrice - totalPrice;

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"You can go home. {moneyLeft:f2} money left.");
            }
            else
            {
                double priceShare = tornamentPrice / 5.0;
                Console.WriteLine($"Sorry, you cannot go home. Each will receive {priceShare:f2} money.");
            }
        }
    }
}
