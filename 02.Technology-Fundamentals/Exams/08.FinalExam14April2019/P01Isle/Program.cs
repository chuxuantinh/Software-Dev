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
                string pattern1 = @"#(?<name>[A-Za-z]+)#=(?<length>[0-9]+)!!(?<code>.+)";
                string pattern2 = @"$(?<name>[A-Za-z]+)$=(?<length>[0-9]+)!!(?<code>.+)";
                string pattern3 = @"%(?<name>[A-Za-z]+)%=(?<length>[0-9]+)!!(?<code>.+)";
                string pattern4 = @"&(?<name>[A-Za-z]+)&=(?<length>[0-9]+)!!(?<code>.+)";
                string pattern5 = @"\*(?<name>[A-Za-z]+)\*=(?<length>[0-9]+)!!(?<code>.+)";
                StringBuilder sb = new StringBuilder();
                bool isValid = (Regex.IsMatch(input, pattern1) || Regex.IsMatch(input, pattern2) || Regex.IsMatch(input, pattern3) || Regex.IsMatch(input, pattern4) || Regex.IsMatch(input, pattern5));
                if (!isValid)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                else
                {
                    Match match1 = Regex.Match(input, pattern1);
                    Match match2 = Regex.Match(input, pattern2);
                    Match match3 = Regex.Match(input, pattern3);
                    Match match4 = Regex.Match(input, pattern4);
                    Match match5 = Regex.Match(input, pattern5);

                    if (int.Parse(match1.Groups["length"].Value) != match1.Groups["code"].Value.Length &&
                        int.Parse(match2.Groups["length"].Value) != match2.Groups["code"].Value.Length &&
                        int.Parse(match3.Groups["length"].Value) != match3.Groups["code"].Value.Length &&
                        int.Parse(match4.Groups["length"].Value) != match4.Groups["code"].Value.Length &&
                        int.Parse(match5.Groups["length"].Value) != match5.Groups["code"].Value.Length)
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                    if (match1.Success)
                    {
                        if (int.Parse(match1.Groups["length"].Value) != match1.Groups["code"].Value.Length)
                        {
                            
                            continue;
                        }
                        else
                        {
                            int length = int.Parse(match1.Groups["length"].Value);
                            string code = match1.Groups["code"].Value;
                            foreach (var symbol in code)
                            {
                                char newSymbol = (char)(symbol + length);
                                sb.Append(newSymbol);
                                
                            }
                            Console.WriteLine($"Coordinates found! {match1.Groups["name"].Value} -> {sb}");
                            return;
                        }
                    }
                    if (match2.Success)
                    {
                        if (int.Parse(match2.Groups["length"].Value) != match2.Groups["code"].Value.Length)
                        {

                            continue;
                        }
                        else
                        {
                            int length = int.Parse(match2.Groups["length"].Value);
                            string code = match2.Groups["code"].Value;
                            foreach (var symbol in code)
                            {
                                char newSymbol = (char)(symbol + length);
                                sb.Append(newSymbol);
                                
                            }
                            Console.WriteLine($"Coordinates found! {match2.Groups["name"].Value} -> {sb}");
                            return;
                        }
                    }
                    if (match3.Success)
                    {
                        if (int.Parse(match3.Groups["length"].Value) != match3.Groups["code"].Value.Length)
                        {

                            continue;
                        }
                        else
                        {
                            int length = int.Parse(match3.Groups["length"].Value);
                            string code = match3.Groups["code"].Value;
                            foreach (var symbol in code)
                            {
                                char newSymbol = (char)(symbol + length);
                                sb.Append(newSymbol);
                               
                            }
                            Console.WriteLine($"Coordinates found! {match3.Groups["name"].Value} -> {sb}");
                            return;
                        }
                    }
                    if (match4.Success)
                    {
                        if (int.Parse(match4.Groups["length"].Value) != match4.Groups["code"].Value.Length)
                        {

                            continue;
                        }
                        else
                        {
                            int length = int.Parse(match4.Groups["length"].Value);
                            string code = match4.Groups["code"].Value;
                            foreach (var symbol in code)
                            {
                                char newSymbol = (char)(symbol + length);
                                sb.Append(newSymbol);
                                
                            }
                            Console.WriteLine($"Coordinates found! {match4.Groups["name"].Value} -> {sb}");
                            return;
                        }
                    }
                    if (match5.Success)
                    {
                        if (int.Parse(match5.Groups["length"].Value) != match5.Groups["code"].Value.Length)
                        {

                            continue;
                        }
                        else
                        {
                            int length = int.Parse(match5.Groups["length"].Value);
                            string code = match5.Groups["code"].Value;
                            foreach (var symbol in code)
                            {
                                char newSymbol = (char)(symbol + length);
                                sb.Append(newSymbol);

                            }
                            Console.WriteLine($"Coordinates found! {match5.Groups["name"].Value} -> {sb}");
                            return;
                        }
                    }
                }
            }
        }
    }
}
