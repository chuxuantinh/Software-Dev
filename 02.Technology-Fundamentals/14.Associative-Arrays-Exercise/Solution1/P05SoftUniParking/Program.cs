using System;
using System.Collections.Generic;

namespace P05SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string username = input[1];
                if (input[0] == "register" && !dict.ContainsKey(username))
                {
                    string licensePlateNumber = input[2];
                    Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    dict.Add(username, licensePlateNumber);
                }
                else if (input[0] == "register" && dict.ContainsKey(username))
                {
                    string licensePlateNumber = input[2];
                    Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                }
                else if (input[0] == "unregister" && dict.ContainsKey(username))
                {
                    Console.WriteLine($"{username} unregistered successfully");
                    dict.Remove(username);
                }
                else if (input[0] == "unregister" && !dict.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: user {username} not found");
                }
            }
            foreach (var user in dict)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
