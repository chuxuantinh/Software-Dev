using System;
using System.Collections.Generic;

namespace P02OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                string wordsInLowerCase = word.ToLower();
                if (counts.ContainsKey(wordsInLowerCase))
                {
                    counts[wordsInLowerCase]++;
                }
                else
                {
                    counts.Add(wordsInLowerCase, 1);
                }
            }
            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}
