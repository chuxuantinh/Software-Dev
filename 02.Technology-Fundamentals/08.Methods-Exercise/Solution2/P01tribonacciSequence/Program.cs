using System;

namespace P01tribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] tribonacci = new long[n];
            if (n >= 1)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        tribonacci[i] = 1;
                    }
                    else if (i == 2)
                    {
                        tribonacci[i] = 2;
                    }
                    else
                    {
                        tribonacci[i] = tribonacci[i - 1] + tribonacci[i - 2] + tribonacci[i - 3];
                    }
                }
                
                Console.WriteLine(string.Join(" ", tribonacci));
                
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
