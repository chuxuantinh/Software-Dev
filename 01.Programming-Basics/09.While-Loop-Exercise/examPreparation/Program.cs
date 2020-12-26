using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int allowedBadGrades = int.Parse(Console.ReadLine());
            int counter = 0;
            int counterBadGrades = 0;
            string input;
            string nameProblem = "";
            double sum = 0;
            while (counterBadGrades < allowedBadGrades)
            {
                input = Console.ReadLine();
                if (input == "Enough")
                {
                    double average = sum / counter;
                    Console.WriteLine($"Average score: {average:f2}");
                    Console.WriteLine($"Number of problems: {counter}");
                    Console.WriteLine($"Last problem: {nameProblem}");
                    break;
                }
                nameProblem = input;
                int grade = int.Parse(Console.ReadLine());
                counter++;
                sum += grade;
                if (grade <= 4)
                {
                    counterBadGrades++;
                }
            }
            if (counterBadGrades == allowedBadGrades)
            {
                Console.WriteLine($"You need a break, {allowedBadGrades} poor grades.");
            }
        }
    }
}
