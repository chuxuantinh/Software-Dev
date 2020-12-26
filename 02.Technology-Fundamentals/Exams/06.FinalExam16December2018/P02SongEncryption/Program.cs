using System;
using System.Text;
using System.Text.RegularExpressions;

namespace P02SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string artistPattern = @"^(?<artist>[A-Z][a-z ']*)$";
            string songPattern = @"^(?<song>[A-Z ]+)$";
            string keepPattern = @"[^' @]";
            string line = Console.ReadLine();
            while (!line.Equals("end"))
            {
                string[] tokens = line.Split(":");
                string artist = tokens[0];
                string song = tokens[1];
                bool artistIsValid = Regex.IsMatch(artist, artistPattern);
                bool songIsValid = Regex.IsMatch(song, songPattern);
                if (!artistIsValid || !songIsValid)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (artistIsValid && songIsValid)
                {
                    Match artistMatch = Regex.Match(artist, artistPattern);
                    Match songMatch = Regex.Match(song, songPattern);
                    StringBuilder sb = new StringBuilder();
                    int length = artist.Length;
                    string text = $"{artistMatch.Groups["artist"].Value}@{songMatch.Groups["song"].Value}";
                    foreach (char symbol in text)
                    {
                        char newSymbol = symbol;
                        bool isValidSymbol = Regex.IsMatch(newSymbol.ToString(), keepPattern);
                        if (isValidSymbol)
                        {
                            newSymbol = (char)(newSymbol + length);
                            if (symbol <= 90 && newSymbol > 90)
                            {
                                newSymbol -= (char)26;
                            }
                            else if (symbol <= 122 && newSymbol > 122)
                            {
                                newSymbol -= (char)26;
                            }
                        }
                        sb.Append(newSymbol);
                    }
                    Console.WriteLine($"Successful encryption: {sb}");

                }
                line = Console.ReadLine();
            }
        }
    }
}
