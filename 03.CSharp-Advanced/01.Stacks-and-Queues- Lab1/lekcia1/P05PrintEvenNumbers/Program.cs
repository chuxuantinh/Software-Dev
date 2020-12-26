using System;
using System.Collections.Generic;
using System.Linq;

namespace P05PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);
            Queue<int> result = new Queue<int>();
            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 == 0)
                {
                    result.Enqueue(queue.Peek());
                    queue.Dequeue();
                }
                else
                {
                    queue.Dequeue();
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
