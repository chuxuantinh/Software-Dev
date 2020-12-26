using System;
using System.Linq;

namespace P04ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split(" ").ToArray();
            for (int i = 0; i < items.Length / 2; i++)
            {
                string oldElement = items[i];
                items[i] = items[items.Length - 1 - i];
                items[items.Length - 1 - i] = oldElement;
            }
            Console.WriteLine(string.Join(" ", items));
        }
    }
}
