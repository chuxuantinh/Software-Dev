using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Concert2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bandNameAndMembers = new Dictionary<string, List<string>>();
            var bandNameAndTime = new Dictionary<string, int>();
            int totalTimeCount = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "start of concert")
                {
                    break;
                }
                string[] tokens = input.Split(new string[] { "; ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Add")
                {
                    var listOfMembers = new List<string>();
                    string bandName = tokens[1];
                    if (!bandNameAndMembers.ContainsKey(bandName))
                    {
                        bandNameAndMembers.Add(bandName, new List<string>());
                    }
                    for (int i = 2; i < tokens.Length; i++)
                    {
                        if (!bandNameAndMembers[bandName].Contains(tokens[i]))
                        {
                            bandNameAndMembers[bandName].Add(tokens[i]);
                        }
                    }
                }
                else if (tokens[0] == "Play")
                {
                    string bandName = tokens[1];
                    int playTime = int.Parse(tokens[2]);
                    if (!bandNameAndTime.ContainsKey(bandName))
                    {
                        bandNameAndTime.Add(bandName, playTime);
                    }
                    else
                    {
                        bandNameAndTime[bandName] += playTime;
                    }
                }
            }
            foreach (var time in bandNameAndTime)
            {
                totalTimeCount += time.Value;
            }
            string finalInput = Console.ReadLine();
            Console.WriteLine($"Total time: {totalTimeCount}");

            foreach (var item in bandNameAndTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
            Console.WriteLine(finalInput);
            foreach (var band in bandNameAndMembers)
            {
                if (band.Key == finalInput)
                {
                    foreach (var memberInBand in band.Value)
                    {
                        Console.WriteLine($"=> {memberInBand}");
                    }
                }
            }
        }
    }
}
