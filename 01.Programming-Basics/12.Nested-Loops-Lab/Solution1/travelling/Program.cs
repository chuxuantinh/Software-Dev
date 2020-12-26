using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string destination = "";
            while (input != "End")
            {
                destination = input;
                double budget = double.Parse(Console.ReadLine());
                double sum = 0;
                double input2 = 0;
                while (sum < budget)
                {
                    input2 = double.Parse(Console.ReadLine());
                    sum += input2;
                    if (sum >= budget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
