using System;

namespace Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int totalDays = int.Parse(Console.ReadLine());

            decimal money = 0m;
            decimal totalMoney = 0m;
            int spirit = 0;

            for (int day = 1; day <= totalDays; day++)
            {
                if (day % 11 == 0)
                {
                    quantity = quantity + 2;
                }
                if (day % 2 == 0)
                {
                    money = quantity * 2m;
                    totalMoney = totalMoney + money;
                    spirit = spirit + 5;
                }
                if (day % 3 == 0)
                {
                    money = quantity * 5m + quantity * 3m;
                    totalMoney = totalMoney + money;
                    spirit = spirit + 13;
                }
                if (day % 5 == 0)
                {
                    money = quantity * 15m;
                    totalMoney = totalMoney + money;
                    spirit = spirit + 17;
                    if (day % 3 == 0)
                    {
                        spirit = spirit + 30;
                    }
                }
                if (day % 10 == 0)
                {
                    spirit = spirit - 20;
                    money = 5m + 3m + 15m;
                    totalMoney = totalMoney + money;
                    if (day == totalDays)
                    {
                        spirit = spirit - 30;
                    }
                }
                
            }
            Console.WriteLine($"Total cost: {totalMoney}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}