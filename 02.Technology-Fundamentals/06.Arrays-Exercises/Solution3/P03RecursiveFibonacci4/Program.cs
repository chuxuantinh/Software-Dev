using System;

namespace P03RecursiveFibonacci4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] fibonacci = new long[n];
            if (n >= 1 && n <= 50)
            {
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
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
