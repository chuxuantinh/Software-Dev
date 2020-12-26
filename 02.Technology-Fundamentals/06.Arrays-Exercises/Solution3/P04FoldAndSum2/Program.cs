using System;
using System.Linq;

namespace _03_Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = numbers.Length / 4;

            Array.Reverse(numbers);

            int[] result = new int[2 * k];
            for (int i = 0; i < k; i++)
            {
                result[i] += numbers[numbers.Length - k + i] + numbers[numbers.Length - k - i - 1];
                result[i + k] += numbers[i] + numbers[numbers.Length - (2 * k) - i - 1];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}