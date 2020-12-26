using System;

namespace P03Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string people = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0.0;
            double totalPrice = 0.0;

            switch (people)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday": price = 8.45; break;
                        case "Saturday": price = 9.80; break;
                        case "Sunday": price = 10.46; break;
                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday": price = 10.90; break;
                        case "Saturday": price = 15.60; break;
                        case "Sunday": price = 16; break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday": price = 15; break;
                        case "Saturday": price = 20; break;
                        case "Sunday": price = 22.50; break;
                    }
                    break;
            }
            totalPrice = price * number;
            if (people == "Students" && number >= 30)
            {
                totalPrice = 0.85 * totalPrice;
            }
            if (people == "Business" && number >= 100)
            {
                totalPrice = totalPrice - 10 * price;
            }
            if (people == "Regular" && number >= 10 && number <= 20)
            {
                totalPrice = 0.95 * totalPrice;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
