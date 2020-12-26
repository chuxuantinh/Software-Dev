using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampraparation2
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());
            int countOfBadgrades = 0;
            int count = 0;
            double totalGrade = 0;
            string lastProblem = "";
            while (true)
            {
                string nameOfExercise = Console.ReadLine();
                if (nameOfExercise == "Enough")
                {
                    double averageGrade = totalGrade / count;
                    Console.WriteLine($"Average score: {averageGrade:f2}");
                    Console.WriteLine($"Number of problems: {count}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }

                int grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    countOfBadgrades++;
                }
                if (countOfBadgrades == badGrades)
                {
                    Console.WriteLine("You need a break, {0} poor grades.", countOfBadgrades);
                    break;
                }
                lastProblem = nameOfExercise;
                totalGrade += grade;
                count++;
            }
        }
    }
}
