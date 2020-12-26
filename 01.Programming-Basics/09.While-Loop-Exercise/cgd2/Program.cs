using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cgd2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int cgd = 0;
            while (firstNumber != 0 && secondNumber != 0)
            {
                if (firstNumber > secondNumber)
                    firstNumber %= secondNumber;
                else
                    secondNumber %= firstNumber;
            }
            if (firstNumber == 0)
                cgd = secondNumber;
            else
                cgd = firstNumber;
            Console.WriteLine(cgd);
        }
        
    }
}
