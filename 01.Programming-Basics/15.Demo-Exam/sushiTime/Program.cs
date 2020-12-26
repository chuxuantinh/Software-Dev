using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sushiTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int numberDishes = int.Parse(Console.ReadLine());
            string order = Console.ReadLine();
            decimal price = 0;
            decimal totalPrice = 0;
            switch (restaurant)
            {
                case "Sushi Zone":
                    switch (sushi)
                    {
                        case "sashimi": price = 4.99m; break;
                        case "maki": price = 5.29m; break;
                        case "uramaki": price = 5.99m; break;
                        case "temaki": price = 4.29m; break;
                    } break;
                case "Sushi Time":
                    switch (sushi)
                    {
                        case "sashimi": price = 5.49m; break;
                        case "maki": price = 4.69m; break;
                        case "uramaki": price = 4.49m; break;
                        case "temaki": price = 5.19m; break;
                    }
                    break;
                case "Sushi Bar":
                    switch (sushi)
                    {
                        case "sashimi": price = 5.25m; break;
                        case "maki": price = 5.55m; break;
                        case "uramaki": price = 6.25m; break;
                        case "temaki": price = 4.75m; break;
                    }
                    break;
                case "Asian Pub":
                    switch (sushi)
                    {
                        case "sashimi": price = 4.50m; break;
                        case "maki": price = 4.80m; break;
                        case "uramaki": price = 5.50m; break;
                        case "temaki": price = 5.50m; break;
                    }
                    break;
                default: Console.WriteLine($"{restaurant} is invalid restaurant!"); break;
            }
            if (order == "Y" && price != 0)
            {
                totalPrice = Math.Ceiling(price * numberDishes * 1.20m);
                Console.WriteLine($"Total price: {totalPrice} lv.");
            }
            else if (order == "N" && price != 0)
            {
                totalPrice = Math.Ceiling(price * numberDishes);
                Console.WriteLine($"Total price: {totalPrice} lv.");
            }
            
        }
    }
}
