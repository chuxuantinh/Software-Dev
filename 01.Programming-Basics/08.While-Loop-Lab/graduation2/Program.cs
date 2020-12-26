using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduation2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            int counterExcluded = 0;
            double sum = 0;

            while (counter <= 12 && counterExcluded < 2)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    sum += grade;
                    counter++;
                }
                else
                {
                    counterExcluded++;
                }
            }
            if (counterExcluded == 2)
            {
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            }
            else
            {
                double average = sum / 12;
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
            }
            
        }
    }
}
