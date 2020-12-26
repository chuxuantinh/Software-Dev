using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01SumAndAverage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            int sum = 0;
            double avrg = 0;

            foreach (int num in numbers)
            {
                sum += num;
            }

            if (sum != 0)
            {
                avrg = (double)sum / numbers.Count;
            }

            Console.WriteLine($"Sum={sum}; Average={avrg:F2}");
        }
    }
}
