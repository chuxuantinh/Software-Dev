using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opretaionBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            string evenOrOdd = "";
            string @operator = Console.ReadLine();
            double result = default(double);
            try
            {
                switch (@operator)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        evenOrOdd = result % 2 == 0 ? "even" : "odd";
                        Console.WriteLine($"{firstNumber} + {secondNumber} = {result} - {evenOrOdd}"); break;
                    case "-":
                        result = firstNumber - secondNumber;
                        evenOrOdd = result % 2 == 0 ? "even" : "odd";
                        Console.WriteLine($"{firstNumber} - {secondNumber} = {result} - {evenOrOdd}"); break;
                    case "*":
                        result = firstNumber * secondNumber;
                        evenOrOdd = result % 2 == 0 ? "even" : "odd";
                        Console.WriteLine($"{firstNumber} * {secondNumber} = {result} - {evenOrOdd}"); break;
                    case "/":
                        result = firstNumber / secondNumber;
                        if (secondNumber == 0)
                        {
                            Console.WriteLine($"Cannot divide {firstNumber} by zero");
                        }
                        evenOrOdd = result % 2 == 0 ? "even" : "odd";
                        Console.WriteLine($"{firstNumber} / {secondNumber} = {result} - {evenOrOdd}"); break;
                    case "%":
                        result = firstNumber % secondNumber;
                        evenOrOdd = result % 2 == 0 ? "even" : "odd";
                        Console.WriteLine($"{firstNumber} + {secondNumber} = {result} - {evenOrOdd}"); break;
                }
            }
        }
    }
}
