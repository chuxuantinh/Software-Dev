using System;
using System.Linq;
using System.Collections.Generic;


namespace _04.Orders
{
    public class Program
    {
        public static void Main()
        {
            var priceAndProduct = new Dictionary<string, double>();
            var countAndProduct = new Dictionary<string, int>();
            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "buy")
                {
                    break;
                }
                
                string[] tokens = input.Split(' ').ToArray();
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                
                if (!countAndProduct.ContainsKey(product))
                {
                    countAndProduct[product] = 0;
                }
                countAndProduct[product] += quantity;
                if (!priceAndProduct.ContainsKey(product))
                {
                    priceAndProduct[product] = 0;
                }
                priceAndProduct[product] = price;
            }

            foreach (var kvp in countAndProduct)
            {
                string product = kvp.Key;
                int quantity = kvp.Value;
                double price = priceAndProduct[product];

                double result = quantity * price;
                Console.WriteLine($"{product} -> {result:f2}");
            }
        }
    }
}