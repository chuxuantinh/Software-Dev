using System;

namespace P02SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;
            int lastDigit;
            while (number != 0)
            {
                lastDigit = number % 10;
                sumOfDigits += lastDigit;
                number /= 10;
            }
            Console.WriteLine(sumOfDigits);
        }
    }
}
