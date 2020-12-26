using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swimming
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeInSeconds = double.Parse(Console.ReadLine());

            double totalTime = distance * timeInSeconds;
            double slowTime = Math.Floor(distance / 15) * 12.5;
            double ivanchoRecord = totalTime + slowTime;
            
            if (ivanchoRecord < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanchoRecord:f2} seconds.");
            }
            else
            {
                double success = ivanchoRecord - record;
                Console.WriteLine($"No, he failed! He was {success:f2} seconds slower.");
            }
        }
    }
}
