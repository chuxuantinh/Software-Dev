using System;

namespace P05MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());
            if (num1 == 0 || num2 == 0 || num3 ==0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                int negativeCounter = 0;
                if (num1 < 0)
                {
                    negativeCounter++;
                }
                if (num2 < 0)
                {
                    negativeCounter++;
                }
                if (num3 < 0)
                {
                    negativeCounter++;
                }
                if (negativeCounter % 2 == 0)
                {
                    Console.WriteLine("positive");
                }
                else if (negativeCounter % 2 != 0)
                {
                    Console.WriteLine("negative");
                }
            } 
        }
    }
}
