namespace P12CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueOfCups = new Queue<int>(cups);
            int[] bottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackOfBottles = new Stack<int>(bottles);
            int wastedLiters = 0;
            while (queueOfCups.Count > 0 && stackOfBottles.Count > 0)
            {
                int currentBottle = stackOfBottles.Peek();
                int currentCup = queueOfCups.Peek();
                if (currentBottle - currentCup >= 0)
                {
                    queueOfCups.Dequeue();
                    stackOfBottles.Pop();
                    wastedLiters += currentBottle - currentCup;
                }
                else
                {
                    while (currentCup > 0 && stackOfBottles.Count > 0)
                    {
                        currentCup -= stackOfBottles.Pop();
                        
                    }
                    wastedLiters += -currentCup;
                    queueOfCups.Dequeue();
                }
            }
            if (queueOfCups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackOfBottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedLiters}");
            }
            else if (stackOfBottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queueOfCups)}");
                Console.WriteLine($"Wasted litters of water: {wastedLiters}");
            }
        }
    }
}
