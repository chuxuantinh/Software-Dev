namespace P05CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<char, int> symbolsCount = new Dictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (!symbolsCount.ContainsKey(currentChar))
                {
                    symbolsCount.Add(currentChar, 0);
                }
                symbolsCount[currentChar]++;
            }
            foreach (var (key, value) in symbolsCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
        }
    }
}
