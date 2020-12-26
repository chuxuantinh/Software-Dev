using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            double liters = length * width * heigth * 0.001;
            double litersNeeded = liters * (1 - percentage/100.0);
            Console.WriteLine("{0:F3}", litersNeeded);
        }
    }
}
