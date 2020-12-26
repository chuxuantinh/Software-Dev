using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double lengthHall = double.Parse(Console.ReadLine());
            double widthHall = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());
            double areaHall = lengthHall * 100 * widthHall * 100;
            double areaA = a * 100 * a * 100;
            double areaBench = areaHall / 10.0;
            double freeSpace = areaHall - areaA - areaBench;
            double numberOfDancers = Math.Floor(freeSpace / (40 + 7000));
            Console.WriteLine(numberOfDancers);
        }
    }
}
