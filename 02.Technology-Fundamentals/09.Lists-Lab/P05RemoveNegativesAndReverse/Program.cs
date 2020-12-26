using System;
using System.Collections.Generic;
using System.Linq;

namespace P05RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> positiveNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number >= 0)
                {
                    positiveNumbers.Add(number);
                }
            }
            positiveNumbers.Reverse();
            if (positiveNumbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", positiveNumbers));
            }
        }
    }
}
