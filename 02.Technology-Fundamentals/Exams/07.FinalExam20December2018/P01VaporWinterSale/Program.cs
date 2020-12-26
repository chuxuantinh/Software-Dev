using System;
using System.Collections.Generic;
using System.Linq;

namespace P01VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> gamesAndPrices = new Dictionary<string, decimal>();
            Dictionary<string, string> gamesAndDlc = new Dictionary<string, string>();
            string[] input = Console.ReadLine().Split(", ");
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains(":"))
                {
                    string[] tokensDlc = input[i].Split(":");
                    string gameName = tokensDlc[0];
                    string dlc = tokensDlc[1];
                    if (gamesAndPrices.ContainsKey(gameName))
                    {
                        gamesAndDlc.Add(gameName, dlc);
                        decimal increasedPrice = gamesAndPrices[gameName] + (gamesAndPrices[gameName] * 0.20m);
                        gamesAndPrices[gameName] = increasedPrice;
                    }
                }
                else
                {
                    string[] tokensWithoutDlc = input[i].Split("-");
                    string gameName = tokensWithoutDlc[0];
                    decimal gamePrice = decimal.Parse(tokensWithoutDlc[1]);
                    gamesAndPrices.Add(gameName, gamePrice);
                }
            }
            var gamesAndLoweredPriceWithoutDlc = new Dictionary<string, decimal>();
            var gamesAndLoweredPriceWithDlc = new Dictionary<string, decimal>();
            foreach (var game in gamesAndPrices)
            {
                string gameName = game.Key;
                decimal price = game.Value;
                if (!gamesAndDlc.ContainsKey(gameName))
                {
                    decimal loweredPrice = price - (price * 0.20m);
                    gamesAndLoweredPriceWithoutDlc.Add(gameName, loweredPrice);
                }
                else
                {
                    decimal loweredPrice = price - (price * 0.50m);
                    gamesAndLoweredPriceWithDlc.Add(gameName, loweredPrice);
                }
            }
            foreach (var kvp in gamesAndLoweredPriceWithDlc.OrderBy(x => x.Value))
            {
                string name = kvp.Key;
                decimal price = kvp.Value;
                Console.WriteLine($"{name} - {gamesAndDlc[kvp.Key]} - {price:f2}");
            }
            foreach (var kvp in gamesAndLoweredPriceWithoutDlc.OrderByDescending(x => x.Value))
            {
                string name = kvp.Key;
                decimal price = kvp.Value;
                Console.WriteLine($"{name} - {price:f2}");
            }
        }
    }
}
