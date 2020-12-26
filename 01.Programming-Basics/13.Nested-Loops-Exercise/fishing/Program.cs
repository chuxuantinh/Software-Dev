using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int quota = int.Parse(Console.ReadLine());
            string command = "";
            double profit = 0;
            double lost = 0;
            int fishCounter = 0;
            while ((command = Console.ReadLine()) != "Stop")
            {
                double currentFishPrice = 0;
                double fishKg = double.Parse(Console.ReadLine());
                fishCounter++;
                
                if (fishCounter % 3 == 0)
                {
                    for (int i = 0; i < command.Length; i++)
                    {
                        currentFishPrice += command[i];
                    }
                    profit += currentFishPrice / fishKg;
                }
                else
                {
                    for (int i = 0; i < command.Length; i++)
                    {
                        currentFishPrice += command[i];
                    }
                    lost += currentFishPrice / fishKg;
                }
                if (fishCounter == quota)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }
            }
            if (profit > lost)
            {
                Console.WriteLine($"Lyubo's profit from {fishCounter} fishes is {profit - lost:f2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {lost - profit:f2} leva today.");
            }

        }
    }
}
