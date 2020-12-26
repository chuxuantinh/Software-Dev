using System;
using System.Collections.Generic;
using System.Linq;

namespace P05EgyptianFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine().Split('/');
            var numerator = long.Parse(number[0]);
            var denominator = long.Parse(number[1]);

            if (denominator <= numerator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Console.Write($"{numerator}/{denominator} = ");

            var index = 2;
            var result = new List<int>();

            while (numerator != 0)
            {
                var nextNumerator = numerator * index;
                var indexNumerator = denominator;

                var remaining = nextNumerator - indexNumerator;

                if (remaining < 0)
                {
                    index++;
                    continue;
                }

                result.Add(index);
                numerator = remaining;
                denominator = denominator * index;
                index++;
            }

            Console.WriteLine(string.Join(" + ", result.Select(r => $"1/{r}")));
        }
    }
}
