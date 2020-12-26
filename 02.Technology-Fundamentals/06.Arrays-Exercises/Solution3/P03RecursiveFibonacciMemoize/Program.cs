using System;

namespace P03RecursiveFibonacciMemoize
{
    class Program
    {
        static void Main(string[] args)
        {
            
            long x = long.Parse(Console.ReadLine());

            long fibonacci = FibWithMemo(x);
            
        }

        private static long FibWithMemo(long x)
        {
            if (x == 0)
            {
                return 0;
            }
            if (x == 1)
            {
                return 1;
            }
            if (FibWithMemo(x) != 0)
            {
                return FibWithMemo(x);
            }
            FibWithMemo(x) = FibWithMemo(x - 1) + FibWithMemo(x - 2);
            return FibWithMemo(x);
        }
    }
}
