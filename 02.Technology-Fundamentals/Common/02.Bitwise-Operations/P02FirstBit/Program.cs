using System;

namespace P02FirstBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = n >> 1;
            Console.WriteLine(n & 1);
        }
    }
}
