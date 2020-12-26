using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05CountOfOccurrences
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            SortedDictionary<int, int> occurrences = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                if (!occurrences.ContainsKey(number))
                {
                    occurrences.Add(number, 0);
                }
                occurrences[number]++;
            }

            foreach (var kvp in occurrences)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
            }
        }
    }
}
