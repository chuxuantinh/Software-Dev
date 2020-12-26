namespace P07TheV_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggerCollection = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                if (input.Contains("joined"))
                {
                    string username = input.Split()[0];
                    if (!vloggerCollection.ContainsKey(username))
                    {
                        vloggerCollection.Add(username, new Dictionary<string, HashSet<string>>());
                        vloggerCollection[username].Add("followings", new HashSet<string>());
                        vloggerCollection[username].Add("followers", new HashSet<string>());
                    }
                }
                else if (input.Contains("followed"))
                {
                    string[] usernames = input.Split();
                    string firstVlogger = usernames[0];
                    string secondVlogger = usernames[2];
                    if (!vloggerCollection.ContainsKey(firstVlogger) || !vloggerCollection.ContainsKey(secondVlogger) || firstVlogger == secondVlogger)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    vloggerCollection[firstVlogger]["followings"].Add(secondVlogger);
                    vloggerCollection[secondVlogger]["followers"].Add(firstVlogger);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggerCollection.Count} vloggers in its logs.");
            int count = 1;
            var sortedVloggers = vloggerCollection
                .OrderByDescending(f => f.Value["followers"].Count)
                .ThenBy(f => f.Value["followings"].Count)
                .ToDictionary(k => k.Key, y => y.Value);

            foreach (var (username, value) in sortedVloggers)
            {
                int followersCount = sortedVloggers[username]["followers"].Count;
                int followingsCount = sortedVloggers[username]["followings"].Count;
                Console.WriteLine($"{count}. {username} : {followersCount} followers, {followingsCount} following");
                if (count == 1)
                {
                    var followersCollection = value["followers"].OrderBy(x => x).ToList();
                    foreach (var currentUsername in followersCollection)
                    {
                        Console.WriteLine($"*  {currentUsername}");
                    }
                }
                count++;
            }
        }
    }
}
