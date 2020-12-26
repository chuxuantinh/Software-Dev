using System;

namespace P02ASCIISumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int start = Math.Min(first, second);
            int end = Math.Max(first, second);
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int currentChar = text[i];
                if (currentChar > start && currentChar < end)
                {
                    sum += currentChar;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
