using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Item
    {
        public double price;
        public double quantity;

        public Item(double p, double q)
        {
            price = p;
            quantity = q;
        }

        public double GetTotalPrice()
        {
            return price * quantity;
        }
        public void UpdateQuantityAndPrice(double price, double newQuantity)
        {
            quantity += newQuantity;
            this.price = price;

        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<String, Item>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "buy")
            {

                string[] inputStrings = input.Split(" ");

                if (!dict.ContainsKey(inputStrings[0]))
                {
                    Item item = new Item(double.Parse(inputStrings[1]), double.Parse(inputStrings[2]));
                    dict.Add(inputStrings[0], item);
                }
                else
                {
                    Item curItem = dict[inputStrings[0]];
                    curItem.UpdateQuantityAndPrice(double.Parse(inputStrings[1]), double.Parse(inputStrings[2]));
                }

            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.GetTotalPrice():F2}");
            }
            
        }
    }
}