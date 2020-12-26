using System;

namespace P05ASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (char i = (char)start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}
