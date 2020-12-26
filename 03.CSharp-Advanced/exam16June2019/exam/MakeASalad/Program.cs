using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vegetables = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
            Queue<string> queueOfVegetables = new Queue<string>(vegetables);

            int[] salads = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfSalads = new Stack<int>(salads);

            List<int> madeSalads = new List<int>();

            while (queueOfVegetables.Count > 0 && stackOfSalads.Count > 0)
            {
                int currentSalad = stackOfSalads.Peek();
                
                int currentSaladCalories = currentSalad;
                while (currentSaladCalories > 0 && queueOfVegetables.Count > 0)
                {
                    string currentVegetable = queueOfVegetables.Dequeue();
                    int currentVegetableCalories = 0;
                    switch (currentVegetable)
                    {
                        case "tomato":
                            currentVegetableCalories = 80;
                            break;
                        case "carrot":
                            currentVegetableCalories = 136;
                            break;
                        case "lettuce":
                            currentVegetableCalories = 109;
                            break;
                        case "potato":
                            currentVegetableCalories = 215;
                            break;
                    }
                    currentSaladCalories -= currentVegetableCalories;
                }
                madeSalads.Add(stackOfSalads.Pop());
            }

            Console.WriteLine(string.Join(" ", madeSalads));
            
            if (queueOfVegetables.Count > 0)
            {
                Console.WriteLine(string.Join(" ", queueOfVegetables));
            }
            else if (stackOfSalads.Count > 0)
            {
                Console.WriteLine(string.Join(" ", stackOfSalads));
            }
        }
    }
}
