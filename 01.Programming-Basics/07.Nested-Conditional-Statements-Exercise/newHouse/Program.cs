using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int numberFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double roses = 5.00;
            double dahlias = 3.80;
            double tulips = 2.80;
            double narcissus = 3.00;
            double gladiolus = 2.50;
            double money = 0;
            if (flower == "Roses" && numberFlowers <= 80)
            {
                money = roses * numberFlowers;
            }
            else if (flower == "Roses" && numberFlowers > 80)
            {
                money = roses * numberFlowers * 0.9;
            }
            else if (flower == "Dahlias" && numberFlowers <= 90)
            {
                money = dahlias * numberFlowers;
            }
            else if (flower == "Dahlias" && numberFlowers > 90)
            {
                money = dahlias * numberFlowers * 0.85;
            }
            else if (flower == "Tulips" && numberFlowers <= 80)
            {
                money = tulips * numberFlowers;
            }
            else if (flower == "Tulips" && numberFlowers > 80)
            {
                money = tulips * numberFlowers * 0.85;
            }
            else if (flower == "Narcissus" && numberFlowers < 120)
            {
                money = narcissus * numberFlowers * 1.15;
            }
            else if (flower == "Narcissus" && numberFlowers >= 120)
            {
                money = narcissus * numberFlowers;
            }
            else if (flower == "Gladiolus" && numberFlowers < 80)
            {
                money = gladiolus * numberFlowers * 1.20;
            }
            else if (flower == "Gladiolus" && numberFlowers >= 80)
            {
                money = gladiolus * numberFlowers;
            }
            if (budget >= money)
            {
                Console.WriteLine("Hey, you have a great garden with {0} {1} and {2:f2} leva left.", numberFlowers, flower, budget - money);
            }
            else
            {
                Console.WriteLine("Not enough money, you need {0:f2} leva more.", money - budget);
            }
        }
    }
}
