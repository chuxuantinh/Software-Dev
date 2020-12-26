using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threeBrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstTime = double.Parse(Console.ReadLine());
            double secondTime = double.Parse(Console.ReadLine());
            double thirdTime = double.Parse(Console.ReadLine());
            double fatherTime = double.Parse(Console.ReadLine());

            double togetherTime = 1.0 / (1.0 / firstTime + 1.0 / secondTime + 1.0 / thirdTime);
            double timeWithBreak = togetherTime * 1.15;
            Console.WriteLine("Cleaning time: {0:F2}", timeWithBreak);
            if (fatherTime - timeWithBreak >= 0)
            {
                Console.WriteLine("Yes, there is a surprise - time left -> {0} hours.", Math.Floor(fatherTime - timeWithBreak));
            }
            else
            {
                Console.WriteLine("No, there isn't a surprise - shortage of time -> {0} hours.", Math.Ceiling(timeWithBreak - fatherTime));
            }
        }
    }
}
