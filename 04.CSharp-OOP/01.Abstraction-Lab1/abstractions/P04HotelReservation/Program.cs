using System;

namespace P04HotelReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (input.Length == 4)
            {
                decimal pricePerDay = decimal.Parse(input[0]);
                int numberOfDays = int.Parse(input[1]);
                Season season = Enum.Parse<Season>(input[2]);
                Discount discount = Enum.Parse<Discount>(input[3]);

                decimal price = PriceCalculator.CalculatePrice(pricePerDay, numberOfDays, season, discount);
                Console.WriteLine($"{price:f2}");
            }
            else
            {
                decimal pricePerDay = decimal.Parse(input[0]);
                int numberOfDays = int.Parse(input[1]);
                Season season = Enum.Parse<Season>(input[2]);
                
                decimal price = PriceCalculator.CalculatePrice(pricePerDay, numberOfDays, season);
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
