using System;

namespace P01SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int lastNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(NumbersComparison(firstNumber, secondNumber, lastNumber));
        }

        static int NumbersComparison(int firstNumber, int secondNumber, int lastNumber)
        {
            if (firstNumber < secondNumber && firstNumber < lastNumber)
            {
                return firstNumber;
            }
            else if (secondNumber < firstNumber && secondNumber < lastNumber)
            {
                return secondNumber;
            }
            else
            {
                return lastNumber;
            }
        }
    }
}
