using System;

namespace P01CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal priceOfFlour = decimal.Parse(Console.ReadLine());
            decimal priceOfEgg = decimal.Parse(Console.ReadLine());
            decimal priceOfApron = decimal.Parse(Console.ReadLine());
            decimal money = priceOfApron * (decimal)Math.Ceiling(students * 1.2) + priceOfEgg * 10 * students + priceOfFlour * (students - students / 5);
            if (money <= budget)
            {
                Console.WriteLine($"Items purchased for {money:f2}$."); 
            }
            else
            {
                Console.WriteLine($"{(money - budget):f2}$ more needed.");
            }
        }
    }
}
