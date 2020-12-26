using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seaTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal moneyForFoodPerDay = decimal.Parse(Console.ReadLine());
            decimal moneyForSouvenirsPerDay = decimal.Parse(Console.ReadLine());
            decimal moneyForHotelPerDay = decimal.Parse(Console.ReadLine());

            decimal litersBenzin = 420 * 7 / 100.0m;
            decimal moneyForBenzin = litersBenzin * 1.85m;
            decimal moneyForFood = moneyForFoodPerDay * 3;
            decimal moneyForSouvenirs = moneyForSouvenirsPerDay * 3;
            decimal moneyForHotel1 = moneyForHotelPerDay * 0.9m;
            decimal moneyForHotel2 = moneyForHotelPerDay * 0.85m;
            decimal moneyForHotel3 = moneyForHotelPerDay * 0.8m;

            decimal totalMoney = moneyForBenzin + moneyForFood + moneyForSouvenirs + moneyForHotel1 + moneyForHotel2 + moneyForHotel3;
            Console.WriteLine($"Money needed: {totalMoney:f2}");
        }
    }
}
