using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            string currentCurrency = Console.ReadLine();
            string convertedCurrency = Console.ReadLine();
            double leva = 0;
            double convertedAmount = 0;
            if (currentCurrency == "BGN")
            {
                 leva = amount;
            }
            else if (currentCurrency == "USD")
            {
                 leva = amount * 1.79549;
            }
            else if (currentCurrency == "EUR")
            {
                 leva = amount * 1.95583;
            }
            else if (currentCurrency == "GBP")
            {
                 leva = amount * 2.53405;
            }
            if (convertedCurrency == "BGN")
            {
                 convertedAmount = leva;
            }
            else if (convertedCurrency == "USD")
            {
                 convertedAmount = leva / 1.79549;
            }
            else if (convertedCurrency == "EUR")
            {
                 convertedAmount = leva / 1.95583;
            }
            else if (convertedCurrency == "GBP")
            {
                 convertedAmount = leva / 2.53405;
            }
            Console.WriteLine("{0:f2} {1}", convertedAmount, convertedCurrency);
        }   
    }
}
