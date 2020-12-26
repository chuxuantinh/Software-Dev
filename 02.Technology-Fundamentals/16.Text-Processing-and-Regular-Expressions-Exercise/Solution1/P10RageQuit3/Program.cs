using System;
using System.Collections.Generic;

namespace _09._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            // repeat
            int timeToRepeat = 0;
            string stringToRepeat = string.Empty;

            // output
            string output = string.Empty;
            List<string> uniqueSymbolsUsed = new List<string>();
            int uniqueSymbolsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    stringToRepeat += input[i];
                }
                else if (char.IsDigit(input[i]))
                {
                    string symbol = string.Empty;
                    if (i < input.Length - 1)
                    {
                        if (char.IsDigit(input[i + 1]))
                        {
                            symbol += input[i];
                            symbol += input[i + 1];
                        }
                        else
                        {
                            symbol += input[i];
                        }
                    }
                    else
                    {
                        symbol += input[i];
                    }

                    timeToRepeat = int.Parse(symbol);
                    for (int j = 0; j < timeToRepeat; j++)
                    {
                        output += stringToRepeat;
                    }
                    stringToRepeat = string.Empty;
                }
            }
            for (int i = 0; i < output.Length; i++)
            {
                if (!uniqueSymbolsUsed.Contains(output[i].ToString()))
                {
                    uniqueSymbolsUsed.Add(output[i].ToString());
                    uniqueSymbolsCount++;
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
            Console.WriteLine(output);
        }
    }
}