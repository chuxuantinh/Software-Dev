using System;
using System.Collections.Generic;
using System.Linq;

namespace P02CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> time = Console.ReadLine().Split().Select(int.Parse).ToList();
            double leftRacerTime = 0;
            
            for (int i = 0; i < time.Count / 2; i++)
            {
                if (time[i] == 0)
                {
                    leftRacerTime *= 0.8;
                }
                else
                {
                    leftRacerTime += time[i];
                }
            }
            double rightRacerTime = 0;
            for (int i = time.Count - 1; i >= time.Count / 2 + 1; i--)
            {
                if (time[i] == 0)
                {
                    rightRacerTime *= 0.8;
                }
                else
                {
                    rightRacerTime += time[i];
                }
            }
            if (leftRacerTime < rightRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacerTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightRacerTime}");
            }
        }
    }
}
