using System;
using System.Collections.Generic;
using System.Linq;

namespace P07StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                }
                dict[name].Add(grade);
            }
            foreach (var kvp in dict.Where(x => x.Value.Average() >= 4.50).OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
