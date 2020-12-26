﻿using System;

namespace P05Orders
{
    class Program
    {
         
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;

            switch (product)
            {
                case "coffee": price = 1.50; break;
                case "water": price = 1.00; break;
                case "coke": price = 1.40; break;
                case "snacks": price = 2.00; break;
            }

            GetTotalPrice(price, quantity);
            
        }

        private static void GetTotalPrice(double price, int quantity)
        {
            Console.WriteLine($"{price * quantity:f2}");
            
        }
    }
}