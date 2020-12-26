using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());
            double socialScholarship = 0;
            double successScholarship = 0;
            bool hasScholarship = false;
            if (income < minimalSalary)
            {
                if (averageGrade > 4.5)
                {
                    socialScholarship = 0.35 * minimalSalary;
                    hasScholarship = true;
                }
            }
            if (averageGrade >= 5.5)
            {
                successScholarship = averageGrade * 25;
                hasScholarship = true;
            }
            if (hasScholarship == false)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (socialScholarship > successScholarship)
            {
                Console.WriteLine("You get a Social scholarship {0} BGN", Math.Floor(socialScholarship));
            }
            else if (successScholarship > socialScholarship)
            {
                Console.WriteLine("You get a scholarship for excellent results {0} BGN", Math.Floor(successScholarship));
            }
        }
    }
}
