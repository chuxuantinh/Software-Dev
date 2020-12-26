using System;
using System.Collections.Generic;
using System.Linq;

namespace P02Santa_sList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kids = Console.ReadLine().Split("&").ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Finished!")
                {
                    break;
                }
                string[] commandParts = command.Split();
                if (commandParts[0] == "Bad")
                {
                    string kidName = commandParts[1];
                    if (!kids.Contains(kidName))
                    {
                        kids.Insert(0, kidName);
                    }
                }
                if (commandParts[0] == "Good")
                {
                    string kidName = commandParts[1];
                    if (kids.Contains(kidName))
                    {
                        kids.Remove(kidName);
                    }
                }
                if (commandParts[0] == "Rename")
                {
                    string kidName = commandParts[1];
                    string newKidName = commandParts[2];
                    if (kids.Contains(kidName))
                    {
                        int indexOfKidName = kids.IndexOf(kidName);
                        kids[indexOfKidName] = newKidName;
                    }
                }
                if (commandParts[0] == "Rearrange")
                {
                    string kidName = commandParts[1];
                    if (kids.Contains(kidName))
                    {
                        kids.Remove(kidName);
                        kids.Add(kidName);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", kids));
        }
    }
}
