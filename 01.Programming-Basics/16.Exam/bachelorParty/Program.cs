using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bachelorParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForSinger = double.Parse(Console.ReadLine());
            string command = "";
            int numberGuests = 0;
            double cuvert = 0.0;
            double totalMoney = 0.0;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "The restaurant is full")
                {
                    break;
                }
                int group = int.Parse(command);
                numberGuests += group;
                if (group >= 5)
                {
                    cuvert = 70;
                }
                else if (group < 5)
                {
                    cuvert = 100;
                }
                totalMoney += cuvert * group;
            }
            if (totalMoney >= moneyForSinger)
            {
                double moneyLeft = totalMoney - moneyForSinger;
                Console.WriteLine($"You have {numberGuests} guests and {moneyLeft} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {numberGuests} guests and {totalMoney} leva income, but no singer.");
            }
        }
    }
}
