using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int itemsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < itemsCount; i++)
            {
                string itemType = Console.ReadLine();
                switch (itemType)
                {
                    case "hoodie": budget -= 30;  break;
                    case "keychain": budget -= 4; break;
                    case "T-shirt": budget -= 20; break;
                    case "flag": budget -= 15; break;
                    case "sticker": budget -= 1; break;
                }
            }
            if (budget >= 0)
            {
                Console.WriteLine($"You bought {itemsCount} items and left with {budget} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {budget * -1} more lv.");
            }
        }
    }
}
