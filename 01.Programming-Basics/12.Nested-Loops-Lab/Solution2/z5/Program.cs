using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z5
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            for (int number1 = 1; number1 <= 49; number1++)
            {
                for (int number2 = number1 + 1; number2 <= 49; number2++)
                {
                    for (int number3 = number2 + 1; number3 <= 49; number3++)
                    {
                        for (int number4 = number3 + 1; number4 <= 49; number4++)
                        {
                            for (int number5 = number4 + 1; number5 <= 49; number5++)
                            {
                                for (int number6 = number5 + 1; number6 <= 49; number6++)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
