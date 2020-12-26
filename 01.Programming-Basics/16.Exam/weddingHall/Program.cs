using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weddingHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double side = double.Parse(Console.ReadLine());
            double areaHall = length * width;
            double areaBar = side * side;
            double areaDancing = areaHall * 0.19;
            double freeSpace = areaHall - areaBar - areaDancing;
            double numberGuests = Math.Ceiling(freeSpace / 3.2);
            Console.WriteLine(numberGuests);
        }
    }
}
