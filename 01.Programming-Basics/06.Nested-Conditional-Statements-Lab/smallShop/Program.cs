using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine().ToLower();
            string town = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());

            if (town == "sofia")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(0.5 * quantity); break;
                    case "water": Console.WriteLine(0.8 * quantity); break;
                    case "beer": Console.WriteLine(1.2 * quantity); break;
                    case "sweets": Console.WriteLine(1.45 * quantity); break;
                    case "peanuts": Console.WriteLine(1.6 * quantity); break;
                }
            }
            else if (town == "plovdiv")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(0.4 * quantity); break;
                    case "water": Console.WriteLine(0.7 * quantity); break;
                    case "beer": Console.WriteLine(1.15 * quantity); break;
                    case "sweets": Console.WriteLine(1.3 * quantity); break;
                    case "peanuts": Console.WriteLine(1.5 * quantity); break;
                }
            }
            else if (town == "varna")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(0.45 * quantity); break;
                    case "water": Console.WriteLine(0.7 * quantity); break;
                    case "beer": Console.WriteLine(1.1 * quantity); break;
                    case "sweets": Console.WriteLine(1.35 * quantity); break;
                    case "peanuts": Console.WriteLine(1.55 * quantity); break;
                }
            }
        }
    }
}
