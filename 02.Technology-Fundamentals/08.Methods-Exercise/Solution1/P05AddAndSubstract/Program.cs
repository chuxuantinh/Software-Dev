using System;

namespace P05AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int lastNumber = int.Parse(Console.ReadLine());
            int sumOfTwoNumbers = SumOfFirstAndSecondNumber(firstNumber, secondNumber);
            Console.WriteLine(Subtract(sumOfTwoNumbers, lastNumber)); 
        }

        private static int Subtract(int sumOfTwoNumbers, int lastNumber)
        {
            return sumOfTwoNumbers - lastNumber;
        }

        private static int SumOfFirstAndSecondNumber(int firstNumber, int secondNumber)
        {
            int sumOfFirstAndSecond = firstNumber + secondNumber;
            return sumOfFirstAndSecond;
        }
    }
}
