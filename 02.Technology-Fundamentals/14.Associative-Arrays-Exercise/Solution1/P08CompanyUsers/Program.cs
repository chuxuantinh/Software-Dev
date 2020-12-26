using System;
using System.Collections.Generic;
using System.Linq;

namespace P08CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" -> ");
                string companyName = tokens[0];
                string id = tokens[1];
                if (!dict.ContainsKey(companyName))
                {
                    dict.Add(companyName, new List<string>());
                }
                if (!dict[companyName].Contains(id))
                {
                    dict[companyName].Add(id);
                }
            }
            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var id in kvp.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
