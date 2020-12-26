using System;
using System.Collections.Generic;
using System.Linq;

namespace P02PracticeSessions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> roads = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split("->");
                if (tokens[0] == "Add")
                {
                    string road = tokens[1];
                    string racer = tokens[2];
                    if (!roads.ContainsKey(road))
                    {
                        roads.Add(road, new List<string>());
                        
                    }
                    roads[road].Add(racer);
                }
                else if (tokens[0] == "Move")
                {
                    string currentRoad = tokens[1];
                    string racer = tokens[2];
                    string nextRoad = tokens[3];
                    if (roads[currentRoad].Contains(racer))
                    {
                        roads[currentRoad].Remove(racer);
                        roads[nextRoad].Add(racer);
                    }
                }
                else if (tokens[0] == "Close")
                {
                    string road = tokens[1];
                    if (roads.ContainsKey(road))
                    {
                        roads.Remove(road);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Practice sessions:");
            foreach (var kvp in roads.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"++{kvp2}");
                }
            }
        }
    }
}
