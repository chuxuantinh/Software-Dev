using System;

namespace P01IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int lastNumber = int.Parse(Console.ReadLine());
            int sum = (firstNumber + secondNumber) / thirdNumber * lastNumber;
            Console.WriteLine(sum);
        }
    }
}
