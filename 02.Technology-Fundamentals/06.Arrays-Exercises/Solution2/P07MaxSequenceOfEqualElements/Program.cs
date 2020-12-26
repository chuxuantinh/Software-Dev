using System;
using System.Linq;

namespace P07MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = 0;
            int len = 1;
            int maxStart = 0;
            int maxLen = 1;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i+1])
                {
                    len++;
                    if (len > maxLen)
                    {
                        maxLen = len;
                        maxStart = start;
                    }
                }
                else
                {
                    start = i + 1;
                    len = 1;
                }
            }
            for (int i = maxStart; i < maxStart + maxLen; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
