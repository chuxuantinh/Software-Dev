using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberFisherman = int.Parse(Console.ReadLine());
            double priceShip = 0;
            if (season == "Spring")
            {
                if (numberFisherman >= 12)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 3000 * 0.75 * 0.95;
                    }
                    else
                    {
                        priceShip = 3000 * 0.75;
                    }
                }
                else if (numberFisherman >= 7)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 3000 * 0.85 * 0.95;
                    }
                    else
                    {
                        priceShip = 3000 * 0.85;
                    }
                }
                else if (numberFisherman >= 1)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 3000 * 0.90 * 0.95;
                    }
                    else
                    {
                        priceShip = 3000 * 0.90;
                    }
                }
            }
            if (season == "Summer")
            {
                if (numberFisherman >= 12)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 4200 * 0.75 * 0.95;
                    }
                    else
                    {
                        priceShip = 4200 * 0.75;
                    }
                }
                else if (numberFisherman >= 7)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 4200 * 0.85 * 0.95;
                    }
                    else
                    {
                        priceShip = 4200 * 0.85;
                    }
                }
                else if (numberFisherman >= 1)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 4200 * 0.90 * 0.95;
                    }
                    else
                    {
                        priceShip = 4200 * 0.90;
                    }
                }
            }
            if (season == "Autumn")
            {
                if (numberFisherman >= 12)
                {
                    priceShip = 4200 * 0.75;
                }
                else if (numberFisherman >= 7)
                {
                    priceShip = 4200 * 0.85;
                }
                else if (numberFisherman >= 1)
                {
                    priceShip = 4200 * 0.90;
                }
            }
            if (season == "Winter")
            {
                if (numberFisherman >= 12)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 2600 * 0.75 * 0.95;
                    }
                    else
                    {
                        priceShip = 2600 * 0.75;
                    }
                }
                else if (numberFisherman >= 7)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 2600 * 0.85 * 0.95;
                    }
                    else
                    {
                        priceShip = 2600 * 0.85;
                    }
                }
                else if (numberFisherman >= 1)
                {
                    if (numberFisherman % 2 == 0)
                    {
                        priceShip = 2600 * 0.90 * 0.95;
                    }
                    else
                    {
                        priceShip = 2600 * 0.90;
                    }
                }
            }
            if (budget >= priceShip)
            {
                Console.WriteLine("Yes! You have {0:f2} leva left.", budget - priceShip);
            }
            else
            {
                Console.WriteLine("Not enough money! You need {0:f2} leva.", priceShip - budget);
            }
        }
    }
}
