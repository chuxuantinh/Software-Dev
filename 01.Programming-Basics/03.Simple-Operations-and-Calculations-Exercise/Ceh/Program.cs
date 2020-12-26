using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceh
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfTable = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double areaPokrivki = numbersOfTable * (length + 2 * 0.30) * (width + 2 * 0.30);
            double areaKareta = numbersOfTable * (length / 2.0) * (length / 2);
            double priceInDollars = areaPokrivki * 7 + areaKareta * 9;
            double priceInLeva = priceInDollars * 1.85;
            Console.WriteLine("{0:F2} USD", priceInDollars);
            Console.WriteLine("{0:f2} BGN", priceInLeva);
        }
    }
}
