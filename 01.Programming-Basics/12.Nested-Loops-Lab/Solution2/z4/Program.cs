using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z4
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            for (int number = 1; number < 10; number++)
            {
                for (int number2 = number + 1; number2 < 10; number2++)
                {
                    Console.WriteLine($"{number} - {number2}");
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
