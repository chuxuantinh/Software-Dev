using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            string input;
            int currentStepsCount = 0;
            while (currentStepsCount < goal)
            {
                input = Console.ReadLine();
                if (input == "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    currentStepsCount += stepsToHome;
                    break;
                }
                else
                {
                    int stepsMade = int.Parse(input);
                    currentStepsCount += stepsMade;
                }
            }
            if (currentStepsCount >= goal)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                int stepsLeft = goal - currentStepsCount;
                Console.WriteLine($"{stepsLeft} more steps to reach goal.");
            }
        }
    }
}
