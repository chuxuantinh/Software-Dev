using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string categoty = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double transport = 0;
            if (people >= 50)
            {
                transport = 0.25 * budget;
            }
            else if (people >= 25)
            {
                transport = 0.4 * budget;
            }
            else if (people >= 10)
            {
                transport = 0.5 * budget;
            }
            else if (people >= 5)
            {
                transport = 0.6 * budget;
            }
            else if (people >= 1)
            {
                transport = 0.75 * budget;
            }
            double remainingMoney = budget - transport;
            double moneyForTickets = 0;
            if (categoty == "VIP")
            {
                moneyForTickets = 499.99 * people;
            }
            else if (categoty == "Normal")
            {
                moneyForTickets = 249.99 * people;
            }
            if (remainingMoney >= moneyForTickets)
            {
                Console.WriteLine("Yes! You have {0:f2} leva left.", remainingMoney - moneyForTickets);
            }
            else
            {
                Console.WriteLine("Not enough money! You need {0:f2} leva.", moneyForTickets - remainingMoney);
            }
        }
    }
}
