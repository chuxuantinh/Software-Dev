using System;

namespace P01MetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            float kilometers = meters / 1000f;
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
