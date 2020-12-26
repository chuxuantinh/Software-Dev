using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converterSwitch
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
            switch (currentCurrency)
            {
                case "BGN": leva = amount; break;
                case "USD": leva = amount * 1.79549; break;
                case "EUR": leva = amount * 1.95583; break;
                case "GBP": leva = amount * 2.53405; break;
            }
            switch (convertedCurrency)
            {
                case "BGN": convertedAmount = leva; break;
                case "USD": convertedAmount = leva / 1.79549; break;
                case "EUR": convertedAmount = leva / 1.95583; break;
                case "GBP": convertedAmount = leva / 2.53405; break;
            }
            Console.WriteLine("{0:f2} {1}", convertedAmount, convertedCurrency);
        }
    }
}
