using System;

namespace P09SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int spice = 0;
            int days = 0;
            while (startingYield >= 100)
            {
                spice += startingYield - 26;
                startingYield -= 10;
                days++;
            }
            if (spice >= 26)
            {
                spice -= 26;
            }
            else
            {
                spice = 0;
            }
            
            Console.WriteLine($"{days}");
            Console.WriteLine($"{spice}");
        }
    }
}
