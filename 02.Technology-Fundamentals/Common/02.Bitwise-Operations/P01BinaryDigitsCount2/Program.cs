using System;

namespace P01BinaryDigitsCount2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bitToFind = int.Parse(Console.ReadLine());
            int counter = 0;
            while (number > 0)
            {
                int reminder = number % 2;
                if (reminder == bitToFind)
                {
                    counter++;
                }
                number /= 2;
            }
            Console.WriteLine(counter);
        }
    }
}
