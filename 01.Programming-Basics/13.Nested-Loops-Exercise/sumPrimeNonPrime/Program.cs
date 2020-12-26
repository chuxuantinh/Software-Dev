using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int sumPrime = 0;
            int sumNonPrime = 0;
            while ((input = Console.ReadLine()) != "stop")
            {
                int num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                else if (num == 0)
                {
                    continue;
                }
                else if (num == 1)
                {
                    sumNonPrime += num;
                }
                else if (num > 1)
                {
                    bool prime = true;
                    for (int i = 2; i <= Math.Sqrt(num); i++)
                    {
                        if (num % i == 0)
                        {
                            prime = false;
                            break;
                        }
                    }
                    if (prime)
                    {
                        sumPrime += num;
                    }
                    else
                    {
                        sumNonPrime += num;
                    }
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
