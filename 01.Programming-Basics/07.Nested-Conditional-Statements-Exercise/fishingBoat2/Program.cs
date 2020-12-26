using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishingBoat2
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherManCount = int.Parse(Console.ReadLine());
            double discount = 0;
            double boatRent = 0;
            double currentSum = 0;

            if (fisherManCount >= 12)
            {
                discount = 0.25;
                if (season == "Spring")
                {
                    boatRent = 3000;
                }
                if (season == "Summer" || season == "Autumn")
                {

                }
            }
            else if (fisherManCount >= 7)
            {
                discount = 0.15;
            }
            else
            {
                discount = 0.1;     
            }
            if (fisherManCount % 2 ==0 && season != "Autumn")
            {
                discount += 0.05;
            }
            double diff = 0;
            if (currentSum >= budget)
            {
                diff = currentSum - budget;
                Console.WriteLine();
            }
            else
            {
                diff =     
            }
        }
    }
}
