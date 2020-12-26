using System;
using System.Collections.Generic;
using System.Linq;

namespace P03SumOfCoins2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = new int[] { 10, 5, 2, 1 };
            coins = coins.OrderByDescending(c => c).ToArray();
            int target = int.Parse(Console.ReadLine());
            
            int sum = 0;
            List<int> result = new List<int>();
            for (int i = 0; i < coins.Length; i++)
            {
                if (sum + coins[i] > target)
                {
                    continue;
                }
                sum += coins[i];
                result.Add(coins[i]);
            }
            if (target != sum)
            {
                Console.WriteLine("No solution found!");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            
        }
    }
}
