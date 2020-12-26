using System;
using System.Collections.Generic;
using System.Linq;

namespace P06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            Predicate<int> isNotDivisible = number => number % divider != 0;

            numbers = numbers
                    .Where(x => isNotDivisible(x))
                    .ToList();

            numbers.Reverse();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
