using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" | ");
            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split(": ");
                if (!dict.ContainsKey(tokens[0]))
                {
                    dict.Add(tokens[0], new List<string>());
                }
                dict[tokens[0]].Add(tokens[1]);
            }
            string[] words = Console.ReadLine().Split(" | ");
            for (int i = 0; i < words.Length; i++)
            {
                if (dict.ContainsKey(words[i]))
                {
                    Console.WriteLine($"{words[i]}");
                    foreach (var kvp in dict.Where(x => x.Key == $"{words[i]}"))
                    {
                        foreach (var definition in kvp.Value.OrderByDescending(x => x.Length))
                        {
                            Console.WriteLine($" -{definition}");
                        }
                    }
                }
            }
            string command = Console.ReadLine();
            if (command == "End")
            {
                return;
            }
            else if (command == "List")
            {
                foreach (var kvp in dict.OrderBy(x => x.Key))
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
            
        }
    }
}
