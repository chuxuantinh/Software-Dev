using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSum
{
    class Program
    {
        static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int>();

            result.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];

                foreach (var number in result.Keys.ToList())
                {
                    var newSum = number + currentNumber;
                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, currentNumber);
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var numbers = new int[] { 3, 5, 1, 4, 2 };

            var sums = CalcSums(numbers);

            var targetSum = 9;

            if (sums.ContainsKey(targetSum))
            {
                Console.WriteLine("Yes");

                while (targetSum != 0)
                {
                    var number = sums[targetSum];

                    Console.Write(number);

                    targetSum -= number;
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
