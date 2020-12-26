using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Engine
    {
        private Dictionary<string, Dictionary<string, long>> bag;

        public Engine()
        {
            bag = new Dictionary<string, Dictionary<string, long>>();
        }

        public void Run()
        {
            long capacity = long.Parse(Console.ReadLine());

            string[] safe = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


           

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long amount = long.Parse(safe[i + 1]);

                string type = string.Empty;
                type = DetermineTypeOfItem(name, type);

                if (type == string.Empty)
                {
                    continue;
                }
                else if (NotEnoughCapacity(capacity, amount))
                {
                    continue;
                }

                string itemToSkip = string.Empty;
                string itemToCheckWith = string.Empty;

                switch (type)
                {
                    case "Gem":
                        itemToSkip = "Gem";
                        itemToCheckWith = "Gold";

                        if (IsItemToSkip(itemToSkip, itemToCheckWith, amount))
                        {
                            continue;
                        } 
                        
                        break;

                    case "Cash":
                        itemToSkip = "Cash";
                        itemToCheckWith = "Gem";

                        if (IsItemToSkip(itemToSkip, itemToCheckWith, amount))
                        {
                            continue;
                        }

                        break;
                }

                if (!bag.ContainsKey(type))
                {
                    bag[type] = new Dictionary<string, long>();
                }

                if (!bag[type].ContainsKey(name))
                {
                    bag[type][name] = 0;
                }

                bag[type][name] += amount;

                
            }

            PrintOutput();
        }

        private bool IsItemToSkip(string itemToSkip, string itemToCheckWith, long amount)
        {
            if (!bag.ContainsKey(itemToSkip))
            {
                if (bag.ContainsKey(itemToCheckWith))
                {
                    if (amount > bag[itemToCheckWith].Values.Sum())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (bag[itemToSkip].Values.Sum() + amount > bag[itemToCheckWith].Values.Sum())
            {
                return true;
            }

            return false;
        }

        private static string DetermineTypeOfItem(string name, string type)
        {
            if (name.Length == 3)
            {
                type = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                type = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                type = "Gold";
            }

            return type;
        }

        private void PrintOutput()
        {
            foreach (var type in bag)
            {
                string typeName = type.Key;
                long totalAmount = type.Value.Values.Sum();
                Console.WriteLine($"<{typeName}> ${totalAmount}");

                var orderedItems = type.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value);
                foreach (var item in orderedItems)
                {
                    string itemName = item.Key;
                    long itemAmount = item.Value;
                    Console.WriteLine($"##{itemName} - {itemAmount}");
                }
            }
        }

        private bool NotEnoughCapacity(long capacity, long amount)
        {
            return capacity < bag.Values.SelectMany(x => x.Values).Sum() + amount;
        }
    }
}
