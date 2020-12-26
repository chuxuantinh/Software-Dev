namespace P01UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> usernames = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (!usernames.ContainsKey(input))
                {
                    usernames.Add(input, 0);
                }
            }
            foreach (var username in usernames)
            {
                Console.WriteLine(username.Key);
            }
        }
    }
}
