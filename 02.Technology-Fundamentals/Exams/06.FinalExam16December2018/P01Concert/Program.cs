using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> bandNameAndBandTime = new Dictionary<string, int>();
            Dictionary<string, List<string>> bandNameAndMembers = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "start of concert")
            {
                string[] tokens = input.Split("; ");
                string command = tokens[0];
                if (command == "Play")
                {
                    string bandName = tokens[1];
                    int bandTime = int.Parse(tokens[2]);
                    if (!bandNameAndBandTime.ContainsKey(bandName))
                    {
                        bandNameAndBandTime.Add(bandName, 0);
                        bandNameAndMembers.Add(bandName, new List<string>());
                    }
                    bandNameAndBandTime[bandName] += bandTime;
                }
                else if (command == "Add")
                {
                    string bandName = tokens[1];
                    string membersList = tokens[2];
                    List<string> members = membersList.Split(", ").ToList();
                    if (!bandNameAndMembers.ContainsKey(bandName))
                    {
                        bandNameAndBandTime.Add(bandName, 0);
                        bandNameAndMembers.Add(bandName, new List<string>());
                    }
                    for (int i = 0; i < members.Count; i++)
                    {
                        if (!bandNameAndMembers[bandName].Contains(members[i]))
                        {
                            bandNameAndMembers[bandName].Add(members[i]);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            string bandNameToPrint = Console.ReadLine();
            Console.WriteLine($"Total time: {bandNameAndBandTime.Values.Sum()}");
            foreach (var kvp in bandNameAndBandTime.OrderByDescending(x => x.Value).ThenBy(x => x))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            Console.WriteLine(bandNameToPrint);

            var kvp1 = bandNameAndMembers.FirstOrDefault(x => x.Key == bandNameToPrint);
            
            foreach (var item in kvp1.Value)
            {
                Console.WriteLine($"=> {item}");
            }


        }
    }
}
