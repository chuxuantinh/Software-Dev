namespace P08Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] tokens = input.Split(":");
                string contestName = tokens[0];
                string password = tokens[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, password);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contetstName = tokens[0];
                string contestPass = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contests.ContainsKey(contetstName))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (contests[contetstName] != contestPass)
                {
                    input = Console.ReadLine();
                    continue;
                }
                // if(!contests.ContainsKey(contetstName) || contests[contetstName] != contestPass)
                if (!submissions.ContainsKey(username))
                {
                    submissions.Add(username, new Dictionary<string, int>());
                }

                if (!submissions[username].ContainsKey(contetstName))
                {
                    submissions[username].Add(contetstName, 0);
                }

                if (submissions[username][contetstName] < points)
                {
                    submissions[username][contetstName] = points;
                }

                input = Console.ReadLine();
            }
            var bestCandidate = submissions.OrderByDescending(v => v.Value.Values.Sum()).FirstOrDefault();
            string bestCandidateName = bestCandidate.Key;
            int topPoints = bestCandidate.Value.Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidateName} with total {topPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var (key, value) in submissions.OrderBy(x => x.Key))
            {
                Console.WriteLine(key);
                foreach (var (contestName, points) in value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestName} -> {points}");
                }
            }
        }
    }
}
