using System;
using System.Collections.Generic;
using System.Linq;

namespace P10PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, string, string, bool> filter = (name, condition, param) =>
            {
                switch (condition)
                {
                    case "StartsWith": return name.StartsWith(param);
                    case "EndsWith": return name.EndsWith(param);
                    case "Length": return name.Length == int.Parse(param);
                    default: return false;    
                }
            };

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                string condition = tokens[1];
                string param = tokens[2];
                if (action == "Remove")
                {
                    names.RemoveAll(x => filter(x, condition, param));
                }
                else if (action == "Double")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (filter(names[i], condition, param))
                        {
                            names.Insert(i, names[i]);
                            i++;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            
            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
