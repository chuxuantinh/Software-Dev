using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMax = double.MinValue;
            double oddMin = double.MaxValue;
            double evenSum = 0;
            double evenMax = double.MinValue;
            double evenMin = double.MaxValue;
            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                }
                else
                {
                    oddSum += num;
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum},");
            if (oddMin != double.MaxValue)
            {
                Console.WriteLine($"OddMin={oddMin},");
            }
            else
            {
                Console.WriteLine("OddMin=No,");
            }
            if (oddMax != double.MinValue)
            {
                Console.WriteLine($"OddMax={oddMax},");
            }
            else
            {
                Console.WriteLine("OddMax=No,");
            }
            Console.WriteLine($"EvenSum={evenSum},");
            if (evenMin != double.MaxValue)
            {
                Console.WriteLine($"EvenMin={evenMin},");
            }
            else
            {
                Console.WriteLine("EvenMin=No,");
            }
            if (evenMax != double.MinValue)
            {
                Console.WriteLine($"EvenMax={evenMax}");
            }
            else
            {
                Console.WriteLine("EvenMax=No");
            }
        }
    }
}
