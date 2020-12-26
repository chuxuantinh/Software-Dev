using System;
using System.Text;
using System.Text.RegularExpressions;

namespace P01Isle
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();
                string pattern = @"(?<first>[#$%*&])(?<name>[A-Za-z]+)(?<second>[#$%*&])=(?<length>[0-9]+)!!(?<code>.+)";
                
                StringBuilder sb = new StringBuilder();
                bool isValid = Regex.IsMatch(input, pattern);
                if (!isValid)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                else
                {
                    Match match = Regex.Match(input, pattern);
                    

                    if (int.Parse(match.Groups["length"].Value) != match.Groups["code"].Value.Length || match.Groups["first"].Value != match.Groups["second"].Value)
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                    
                    else
                    {
                        int length = int.Parse(match.Groups["length"].Value);
                        string code = match.Groups["code"].Value;
                        foreach (var symbol in code)
                        {
                            char newSymbol = (char)(symbol + length);
                            sb.Append(newSymbol);

                        }
                        Console.WriteLine($"Coordinates found! {match.Groups["name"].Value} -> {sb}");
                        return;
                    }
                    
                    
                }
            }
        }
    }
}
