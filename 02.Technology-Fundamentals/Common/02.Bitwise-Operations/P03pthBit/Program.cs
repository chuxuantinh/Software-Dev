using System;

namespace P03pthBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            n = n >> p;
            Console.WriteLine(n & 1);
        }
    }
}
