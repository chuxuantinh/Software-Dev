using System;
using System.Collections.Generic;
using System.Linq;

namespace P06Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(" : ");
                string courseName = tokens[0];
                string studentName = tokens[1];
                if (!dict.ContainsKey(courseName))
                {
                    dict.Add(courseName, new List<string>());
                }
                dict[courseName].Add(studentName);
            }
            foreach (var kvp1 in dict.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp1.Key}: {kvp1.Value.Count}");
                foreach (var student in kvp1.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
