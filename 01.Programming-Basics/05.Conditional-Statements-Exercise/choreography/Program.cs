using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double steps = double.Parse(Console.ReadLine());
            double dancers = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());

            double stepsPerDayPercent = Math.Ceiling((1 * 100 / days));
            double percentStepsPerDancer = stepsPerDayPercent / dancers;
            if (stepsPerDayPercent <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentStepsPerDancer:f2}%.");
            }
            else
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {percentStepsPerDancer:f2}% steps to be learned per day.");
            }
        }
    }
}
