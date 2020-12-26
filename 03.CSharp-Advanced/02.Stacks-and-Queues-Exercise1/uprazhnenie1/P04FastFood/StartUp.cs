namespace P04FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int foodAmount = int.Parse(Console.ReadLine());
            int[] inputOrders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueOfOrders = new Queue<int>(inputOrders);
            Console.WriteLine(queueOfOrders.Max());
            while (queueOfOrders.Count > 0)
            {
                int currentOrder = queueOfOrders.Peek();
                if (foodAmount - currentOrder < 0)
                {
                    break;
                }
                foodAmount -= queueOfOrders.Dequeue();
            }
            if (queueOfOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queueOfOrders)}");
            }
        }
    }
}
