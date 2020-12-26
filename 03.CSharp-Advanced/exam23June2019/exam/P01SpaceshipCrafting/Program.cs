using System;
using System.Collections.Generic;
using System.Linq;

namespace P01SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquids = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] items = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfLiquids = new Queue<int>(liquids);
            Stack<int> stackOfItems = new Stack<int>(items);
            Dictionary<string, int> materials = new Dictionary<string, int>();

            while (queueOfLiquids.Count > 0 && stackOfItems.Count > 0)
            {
                int currentLiquid = queueOfLiquids.Dequeue();
                int currentItem = stackOfItems.Pop();
                if (currentLiquid + currentItem == 25)
                {
                    if (!materials.ContainsKey("Glass"))
                    {
                        materials.Add("Glass", 0);
                    }
                    materials["Glass"]++;
                }
                else if (currentLiquid + currentItem == 50)
                {
                    if (!materials.ContainsKey("Aluminium"))
                    {
                        materials.Add("Aluminium", 0);
                    }
                    materials["Aluminium"]++;
                }
                else if (currentLiquid + currentItem == 75)
                {
                    if (!materials.ContainsKey("Lithium"))
                    {
                        materials.Add("Lithium", 0);
                    }
                    materials["Lithium"]++;
                }
                else if (currentLiquid + currentItem == 100)
                {
                    if (!materials.ContainsKey("Carbon fiber"))
                    {
                        materials.Add("Carbon fiber", 0);
                    }
                    materials["Carbon fiber"]++;
                }
                else
                {
                    currentItem += 3;
                    stackOfItems.Push(currentItem);
                }
            }
            if (materials.ContainsKey("Glass") && materials.ContainsKey("Aluminium") && materials.ContainsKey("Lithium") && materials.ContainsKey("Carbon fiber"))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            if (!materials.ContainsKey("Glass"))
            {
                materials.Add("Glass", 0);
            }
            if (!materials.ContainsKey("Aluminium"))
            {
                materials.Add("Aluminium", 0);
            }
            if (!materials.ContainsKey("Lithium"))
            {
                materials.Add("Lithium", 0);
            }
            if (!materials.ContainsKey("Carbon fiber"))
            {
                materials.Add("Carbon fiber", 0);
            }
            if (queueOfLiquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queueOfLiquids)}");
            }
            if (stackOfItems.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", stackOfItems)}");
            }
            var orderedMaterials = materials.OrderBy(m => m.Key);
            foreach (var kvp in orderedMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
