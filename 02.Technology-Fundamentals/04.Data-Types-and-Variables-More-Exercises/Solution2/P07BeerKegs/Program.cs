using System;

namespace P07BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double volume = 0;
            string biggestModel = "";
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volumeNew = Math.PI * radius * radius * height;
                if (volumeNew > volume)
                {
                    biggestModel = model;
                    volume = volumeNew;
                }
            }
            Console.WriteLine($"{biggestModel}");
        }
    }
}
