using System;

namespace P01Hunting
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());
            double water = waterPerPerson * players * days;
            double food = foodPerPerson * players * days;
            double energyLoss = 0;
            for (int i = 1; i <= days; i++)
            {
                energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;
                if (energy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {food:f2} food and {water:f2} water.");
                    return;
                }
                if (i % 2 == 0)
                {
                    energy *= 1.05;
                    water *= 0.70;
                }
                if (i % 3 == 0)
                {
                    energy *= 1.10;
                    food = food - food / players;
                }
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
        }
    }
}
