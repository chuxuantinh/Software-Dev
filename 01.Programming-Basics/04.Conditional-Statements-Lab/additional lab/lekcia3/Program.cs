using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekcia3
{
    class Program
    {
        static void Main(string[] args)
        {
            int lunchBreak = int.Parse(Console.ReadLine());
            double hardwareItemPrice = double.Parse(Console.ReadLine());
            double softwareItemPrice = double.Parse(Console.ReadLine());
            double frapePrice = double.Parse(Console.ReadLine());

            int restTimeLeft = lunchBreak - (5 + (3 * 2) + (2 * 2));

            double hardwareTotalPrice = 3 * hardwareItemPrice;
            double softwareTotalPrice = 2 * softwareItemPrice;

            double totalMoneySpent = hardwareTotalPrice + softwareTotalPrice + frapePrice;

            Console.WriteLine($"{totalMoneySpent:f2}");
            Console.WriteLine(restTimeLeft);
        }
    }
}
