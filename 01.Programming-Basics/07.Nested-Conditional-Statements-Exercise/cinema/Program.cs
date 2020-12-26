using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            double premiere = 12.00;
            double normal = 7.50;
            double discount = 5.00;
            double income = 0;

            if (projection == "Premiere")
            {
                income = row * col * premiere;
            }
            else if (projection == "Normal")
            {
                income = row * col * normal;
            }
            else if (projection == "Discount")
            {
                income = row * col * discount;
            }
            Console.WriteLine("{0:f2} leva", income);
        }
    }
}
