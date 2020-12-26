using System;
using System.Linq;

namespace P02RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Factoriel(number));
        }

        private static long Factoriel(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factoriel(--number);
        }
    }
}
