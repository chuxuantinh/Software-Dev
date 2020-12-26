using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWiskey = double.Parse(Console.ReadLine());
            double amountBeer = double.Parse(Console.ReadLine());
            double amountWine = double.Parse(Console.ReadLine());
            double amountRakia = double.Parse(Console.ReadLine());
            double amountWiskey = double.Parse(Console.ReadLine());
            double priceRakia = priceWiskey / 2.0;
            double priceWine = priceRakia * 0.6;
            double priceBeer = priceRakia * 0.2;
            double moneyRakia = amountRakia * priceRakia;
            double moneyWine = amountWine * priceWine;
            double moneyBeer = amountBeer * priceBeer;
            double moneyWiskey = amountWiskey * priceWiskey;
            double moneyTotal = moneyRakia + moneyWine + moneyBeer + moneyWiskey;
            Console.WriteLine("{0:f2}", moneyTotal);
        }
    }
}
