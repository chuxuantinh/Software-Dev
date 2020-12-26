using System;

namespace P03RecursiveFibonacci3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            long[] fibonacci = new long[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == 1)
                {
                    fibonacci[i] = 1;
                }
                else
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                }
            }
            Console.WriteLine(fibonacci[n - 1]);
        }
    }
}
