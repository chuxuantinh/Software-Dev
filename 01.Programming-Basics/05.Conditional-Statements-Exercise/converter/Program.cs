using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string firstUnit = Console.ReadLine();
            string secondUnit = Console.ReadLine();
            double meters = 0;
            double convertedNumber = 0;

            if (firstUnit == "m")
            {
                meters = number;
            }
            else if (firstUnit == "mm")
            {
                meters = number / 1000.0;
            }
            else if (firstUnit == "cm")
            {
                meters = number / 100.0;
            }
            else if (firstUnit == "mi")
            {
                meters = number / 0.000621371192;
            }
            else if (firstUnit == "in")
            {
                meters = number / 39.3700787;
            }
            else if (firstUnit == "km")
            {
                meters = number / 0.001;
            }
            else if (firstUnit == "ft")
            {
                meters = number / 3.2808399;
            }
            else if (firstUnit == "yd")
            {
                meters = number / 1.0936133;
            }
            if (secondUnit == "m")
            {
                convertedNumber = meters;
            }
            else if (secondUnit == "mm")
            {
                convertedNumber = meters * 1000;
            }
            else if (secondUnit == "cm")
            {
                convertedNumber = meters * 100;
            }
            else if (secondUnit == "mi")
            {
                convertedNumber = meters * 0.000621371192;
            }
            else if (secondUnit == "in")
            {
                convertedNumber = meters * 39.3700787;
            }
            else if (secondUnit == "km")
            {
                convertedNumber = meters * 0.001;
            }
            else if (secondUnit == "ft")
            {
                convertedNumber = meters * 3.2808399;
            }
            else if (secondUnit == "yd")
            {
                convertedNumber = meters * 1.0936133;
            }
            Console.WriteLine("{0:f8}", convertedNumber);
        }
    }
}
