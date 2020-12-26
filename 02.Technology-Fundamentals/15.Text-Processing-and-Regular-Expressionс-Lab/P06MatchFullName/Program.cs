using System;
using System.Text.RegularExpressions;

namespace P06MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]+[\s{1}][A-Z][a-z]+\b";
            string names = Console.ReadLine();
            MatchCollection matched = Regex.Matches(names, regex);

            foreach (var name in matched)
            {
                Console.Write(name + " ");
            }

        }
    }
}
