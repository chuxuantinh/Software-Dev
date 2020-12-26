using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glasOfWater
{
    class Program
    {
        static void Main(string[] args)
        {
            double volume = double.Parse(Console.ReadLine());
            double currentVolume = 0.0;
            string input;
            int counter = 0;
            while (currentVolume < volume)
            {
                input = Console.ReadLine();
                if (input == "Easy")
                {
                    currentVolume += 50;
                    counter++;
                }
                else if (input == "Medium")
                {
                    currentVolume += 100;
                    counter++;
                }
                else if (input == "Hard")
                {
                    currentVolume += 200;
                    counter++;
                }
            }
            if (currentVolume == volume)
            {
                Console.WriteLine($"The dispenser has been tapped {counter} times.");
            }
            else
            {
                double spilledVolume = currentVolume - volume;
                Console.WriteLine($"{spilledVolume}ml has been spilled.");
            }
        }
    }
}
