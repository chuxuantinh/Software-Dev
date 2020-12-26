using System;
using System.Text.RegularExpressions;

namespace P08MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            string input = Console.ReadLine();
            MatchCollection matched = Regex.Matches(input, pattern);
            foreach (var number in matched)
            {
                Console.Write(number + " ");
            }
            
        }
    }
}
