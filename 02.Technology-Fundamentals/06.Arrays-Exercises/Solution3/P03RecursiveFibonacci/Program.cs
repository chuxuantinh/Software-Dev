using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static int[] results;
        static void Main()
        {
            int fibonacciNumber = int.Parse(Console.ReadLine());
            results = new int[fibonacciNumber];
            int result = GetFibonacciNumber(fibonacciNumber);
            Console.WriteLine(result);
        }

        private static int GetFibonacciNumber(int fibonacciNumber)
        {
            int result;
            if (results[fibonacciNumber - 1] != 0)
            {
                return results[fibonacciNumber - 1];
            }
            if (fibonacciNumber == 2)
            {
                results[fibonacciNumber - 1] = 1;

                return 1;
            }
            else if (fibonacciNumber == 1)
            {
                results[fibonacciNumber - 1] = 1;

                return 1;
            }

            result = GetFibonacciNumber(fibonacciNumber - 1) + GetFibonacciNumber(fibonacciNumber - 2);
            if (results[fibonacciNumber - 1] == 0)
            {
                results[fibonacciNumber - 1] = result;
            }

            return result;

        }
    }
}