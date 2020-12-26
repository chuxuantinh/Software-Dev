using System;

namespace P04BitDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int mask = 1 << p;
            mask = ~mask;
            Console.WriteLine(n & mask);
        }
    }
}
