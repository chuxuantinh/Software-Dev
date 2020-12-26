using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            string place = "";
            double result = 0;
            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "winter": result = budget * 0.7; place = "Hotel"; break;
                    case "summer": result = budget * 0.3; place = "Camp"; break;
                }
            }
            else if (budget <= 1000 && budget > 100)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "winter": result = budget * 0.8; place = "Hotel"; break;
                    case "summer": result = budget * 0.4; place = "Camp"; break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                place = "Hotel";
                result = budget * 0.9;
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine("{0} - {1:f2}", place, result);
        }
    }
}
