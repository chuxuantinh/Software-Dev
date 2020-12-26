using System;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = Console.ReadLine()
                .MySplit();

            Console.WriteLine(string.Join(" ", test));
        }
    }
}
