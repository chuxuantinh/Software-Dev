using System;
using System.Collections.Generic;
using System.Linq;

namespace P09ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict1 = new Dictionary<string, List<string>>();
            var dict2 = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                List<string> tokens1 = input.Split().ToList();
                if (tokens1.Contains("|"))
                {
                    string[] tokens2 = input.Split(" | ");
                    string forceSide = tokens2[0];
                    string forceUser = tokens2[1];
                    if (dict1.Keys == null && dict2.Keys == null)
                    {
                        dict1.Add(forceSide, new List<string>());
                        dict1[forceSide].Add(forceUser);
                    }
                    else if (!dict1.ContainsKey(forceSide) && dict2.Keys == null)
                    {
                        dict2.Add(forceSide, new List<string>());
                        dict2[forceSide].Add(forceUser);
                    }
                    else if (dict1.ContainsKey(forceSide) && !dict1[forceSide].Contains(forceUser))
                    {
                        dict1[forceSide].Add(forceUser);
                    }
                    else if (dict2.ContainsKey(forceSide) && !dict2[forceSide].Contains(forceUser))
                    {
                        dict2[forceSide].Add(forceUser);
                    }
                }
                else if (tokens1.Contains("->"))
                {
                    string[] tokens2 = input.Split(" -> ");
                    string forceUser = tokens2[0];
                    string forceSide = tokens2[1];
                    if (dict1.Keys == null && dict2.Keys == null)
                    {
                        dict1.Add(forceSide, new List<string>());
                        dict1[forceSide].Add(forceUser);
                    }
                    else if (!dict1.ContainsKey(forceSide) && dict2.Keys == null)
                    {
                        dict2.Add(forceSide, new List<string>());
                        dict2[forceSide].Add(forceUser);
                    }
                    else if (dict1.ContainsKey(forceSide) && !dict1[forceSide].Contains(forceUser))
                    {
                        dict1[forceSide].Add(forceUser);
                    }
                    else if (dict2.ContainsKey(forceSide) && !dict2[forceSide].Contains(forceUser))
                    {
                        dict2[forceSide].Add(forceUser);
                    }
                }
            }
        }
    }
}
