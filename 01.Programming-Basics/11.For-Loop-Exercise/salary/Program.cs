using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                
                if (text == "Facebook")
                {
                    salary -= 150;
                    if (salary <= 0)
                    {
                        break;
                    }
                }
                else if (text == "Instagram")
                {
                    salary -= 100;
                    if (salary <= 0)
                    {
                        break;
                    }
                }
                else if (text == "Reddit")
                {
                    salary -= 50;
                    if (salary <= 0)
                    {
                        break;
                    }
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(Math.Round(salary, 0));
            }
        }
    }
}
