using System;

namespace P12refactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int num = 1; num <= n; num++)
            {
                int digits = num;
                int sumOfDigits = 0;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits /= 10;
                }
                bool isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine("{0} -> {1}", num, isSpecial);
            }

        }
    }
}
