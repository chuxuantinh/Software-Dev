using System;
using System.Collections.Generic;
using System.Linq;

namespace P02Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("#").ToArray();
            int water = int.Parse(Console.ReadLine());
            int totalFire = 0;
            double effort = 0;
            List<int> cells = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split(" = ");
                string typeOfFire = tokens[0];
                int levelOfFire = int.Parse(tokens[1]);
                if (typeOfFire == "High" && 81 <= levelOfFire && levelOfFire <= 125)
                {
                    if (water >= levelOfFire)
                    {
                        water -= levelOfFire;
                        effort += 0.25 * levelOfFire;
                        totalFire += levelOfFire;
                        cells.Add(levelOfFire);
                    }
                }
                else if (typeOfFire == "Medium" && 51 <= levelOfFire && levelOfFire <= 80)
                {
                    if (water >= levelOfFire)
                    {
                        water -= levelOfFire;
                        effort += 0.25 * levelOfFire;
                        totalFire += levelOfFire;
                        cells.Add(levelOfFire);
                    }
                }
                else if (typeOfFire == "Low" && 1 <= levelOfFire && levelOfFire <= 50)
                {
                    if (water >= levelOfFire)
                    {
                        water -= levelOfFire;
                        effort += 0.25 * levelOfFire;
                        totalFire += levelOfFire;
                        cells.Add(levelOfFire);
                    }
                }
            }
            Console.WriteLine("Cells:");
            foreach (int cell in cells)
            {
                Console.WriteLine($"- {cell}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
