using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double shipWidth = double.Parse(Console.ReadLine());
            double shipLength = double.Parse(Console.ReadLine());
            double shipHeight = double.Parse(Console.ReadLine());
            double averageHeight = double.Parse(Console.ReadLine());
            double volumeShip = shipWidth * shipLength * shipHeight;
            double volumeRoom = (averageHeight + 0.4) * 2 * 2;
            double numberAstronauts = Math.Floor(volumeShip / volumeRoom);
            if (numberAstronauts > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
            else if (numberAstronauts >= 3)
            {
                Console.WriteLine($"The spacecraft holds {numberAstronauts} astronauts.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too small.");
            }
        }
    }
}
