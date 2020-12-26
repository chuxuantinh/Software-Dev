using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string text = Console.ReadLine();
            string result = string.Empty;
            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                int number = numbers[i];
                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                while (sum >= text.Length)
                {
                    sum -= text.Length;
                }
                result += text.Substring(sum, 1);
                text = text.Remove(sum, 1);
            }
            Console.WriteLine(result);
        }
    }
}
