using System;
using System.Collections.Generic;

namespace P01ExchangeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Random random = new Random();
            List<string> shuffledWords = new List<string>();
            foreach (string word in words)
            {
                int newIndex = random.Next(0, shuffledWords.Count + 1);
                shuffledWords.Insert(newIndex, word);
            }
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
