using System;
using System.Collections.Generic;
using System.Linq;

namespace P03CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int quality = int.MinValue;
            List<int> batchResult = new List<int>();
            double averageQuality = double.MinValue;
            int count = 0;
            while (command != "Bake It!")
            {
                List<int> breads = command.Split("#").Select(int.Parse).ToList();
                if (breads.Sum() > quality)
                {
                    quality = breads.Sum();
                    averageQuality = breads.Sum() / (double)breads.Count;
                    batchResult = breads;
                    count = breads.Count;
                }
                else if (breads.Sum() == quality && breads.Sum() / (double)breads.Count > averageQuality)
                {
                    quality = breads.Sum();
                    averageQuality = breads.Sum() / (double)breads.Count;
                    batchResult = breads;
                    count = breads.Count;
                }
                else if (breads.Sum() == quality && breads.Sum() / (double)breads.Count == averageQuality && breads.Count < count)
                {
                    quality = breads.Sum();
                    averageQuality = breads.Sum() / (double)breads.Count;
                    batchResult = breads;
                    count = breads.Count;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {quality}");
            Console.WriteLine(string.Join(" ", batchResult));

        }
    }
}
