using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal returnSum = decimal.Parse(Console.ReadLine());
            int counter = 0;

            while (returnSum >= 0.001m)
            {
                if (Math.Floor(returnSum) >= 2)
                {
                    returnSum -= 2;
                    counter++;
                }
                else if (Math.Floor(returnSum) >= 1)
                {
                    returnSum -= 1;
                    counter++;
                }
                else if (Math.Floor(returnSum) == 0 && returnSum >= 0.50m)
                {
                    returnSum -= 0.50m;
                    counter++;
                }
                else if (Math.Floor(returnSum) == 0 && returnSum >= 0.20m)
                {
                    returnSum -= 0.20m;
                    counter++;
                }
                else if (Math.Floor(returnSum) == 0 && returnSum >= 0.10m)
                {
                    returnSum -= 0.10m;
                    counter++;
                }
                else if (Math.Floor(returnSum) == 0 && returnSum >= 0.05m)
                {
                    returnSum -= 0.05m;
                    counter++;
                }
                else if (Math.Floor(returnSum) == 0 && returnSum >= 0.02m)
                {
                    returnSum -= 0.02m;
                    counter++;
                }
                else if (Math.Floor(returnSum) == 0 && returnSum >= 0.01m)
                {
                    returnSum -= 0.01m;
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
