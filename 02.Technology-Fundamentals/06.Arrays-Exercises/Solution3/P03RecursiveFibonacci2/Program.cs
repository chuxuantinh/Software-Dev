using System;

namespace P03RecursiveFibonacci2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long first = 0;
            long second = 1;
            long third = second + first;
            for (int i = 0; i < n; i++)
            {
                first = second;
                second = third;
                third = first + second;
            }
            Console.WriteLine(first);
        }
    }
}
