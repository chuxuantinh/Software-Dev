using System;
using System.Collections.Generic;
using System.Linq;

namespace P03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            dict["fragments"] = 0;
            dict["motes"] = 0;
            dict["shards"] = 0;
            var junks = new Dictionary<string, int>();
            while (true)
            {
                bool haveWinner = false;
                var tokens = Console.ReadLine().ToLower().Split().ToArray();
                for (int i = 0; i < tokens.Length; i += 2)
                {
                    string type = tokens[i + 1];
                    int quantity = int.Parse(tokens[i]);
                    if (type == "fragments" || type == "motes" || type == "shards")
                    {
                        if (!dict.ContainsKey(type))
                        {
                            dict.Add(type, quantity);
                        }
                        else
                        {
                            dict[type] += quantity;
                        }
                    }
                    else
                    {
                        if (!junks.ContainsKey(type))
                        {
                            junks.Add(type, quantity);
                        }
                        else
                        {
                            junks[type] += quantity;
                        }
                    }
                    if (dict["motes"] >= 250 || dict["shards"] >= 250 || dict["fragments"] >= 250)
                    {
                        dict[type] = dict[type] - 250;
                        if (type == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                        }
                        else if (type == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");
                        }
                        else if (type == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                        }
                        haveWinner = true;
                        break;
                    }

                }
                if (haveWinner)
                {
                    break;
                }
            }

            
            foreach (var kvp in dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            foreach (var kvp in junks.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
