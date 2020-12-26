using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weddingInvestment
{
    class Program
    {
        static void Main(string[] args)
        {
            string duration = Console.ReadLine();
            string type = Console.ReadLine();
            string desert = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double monthTax = 0.0;
            double totalMoney = 0.0;
            switch (duration)
            {
                case "one":
                    switch (type)
                    {
                        case "Small": monthTax = 9.98; break;
                        case "Middle": monthTax = 18.99; break;
                        case "Large": monthTax = 25.98; break;
                        case "ExtraLarge": monthTax = 35.99; break;
                    }
                    break;
                case "two":
                    switch (type)
                    {
                        case "Small": monthTax = 8.58; break;
                        case "Middle": monthTax = 17.09; break;
                        case "Large": monthTax = 23.59; break;
                        case "ExtraLarge": monthTax = 31.79; break;
                    }
                    break;
            }
            if (desert == "yes" && monthTax > 30)
            {
                monthTax += 3.85;
            }
            else if (desert == "yes" && monthTax > 10)
            {
                monthTax += 4.35;
            }
            else if (desert == "yes" && monthTax <= 10)
            {
                monthTax += 5.50;
            }
            else if (desert == "no")
            {
                monthTax = monthTax;
            }
            if (duration == "one")
            {
                totalMoney = monthTax * months;
            }
            else if (duration == "two")
            {
                totalMoney = monthTax * months;
                totalMoney = totalMoney - 3.75 * totalMoney / 100;
            }
            Console.WriteLine($"{totalMoney:f2} lv.");   
            
        }
    }
}
