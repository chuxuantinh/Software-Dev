using System;

namespace P02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                string temp = words[i];
                int positionToExchange = rnd.Next(0, words.Length);
                words[i] = words[positionToExchange];
                words[positionToExchange] = temp;
            }
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
