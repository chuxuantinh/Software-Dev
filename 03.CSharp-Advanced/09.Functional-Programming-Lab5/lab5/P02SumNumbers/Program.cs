using System;
using System.Linq;

namespace P02SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
              .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(Parse)
              .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }

        public static Func<string, int> Parse = n => int.Parse(n);
    }
}
