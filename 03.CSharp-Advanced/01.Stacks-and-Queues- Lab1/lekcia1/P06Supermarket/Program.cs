using System;
using System.Collections.Generic;
using System.Linq;

namespace P06Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string command = Console.ReadLine();
            
            while (command?.ToLower() != "end")
            {
                if (command?.ToLower() == "paid")
                {
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()}");
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
