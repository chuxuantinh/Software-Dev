using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double saturdayGames = (48 - h) * 3.0 / 4;
            double holydayGames = p * 2.0 / 3;
            double games = saturdayGames + h + holydayGames;
            double totalGames = 0;
            if (year == "leap")
            {
                totalGames = 1.15 * games;
            }
            else if (year == "normal")
            {
                totalGames = games;
            }
            Console.WriteLine(Math.Floor(totalGames));
        }
    }
}
