using System;

namespace P10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintMasterNumbers(n);
        }

        private static void PrintMasterNumbers(int n)
        {
            
            for (int i = 1; i <= n; i++)
            {
                bool sumOfDigitsIsDivisibleByEight = CheckSumOfDigitsIsDivisibleByEight(i);
                bool isHoldingAtLeastOneOddDigit = CheckHoldsAtLeastOneOddDigit(i);
                if (sumOfDigitsIsDivisibleByEight && isHoldingAtLeastOneOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool CheckHoldsAtLeastOneOddDigit(int i)
        {
            while (i > 0)
            {
                if (i % 10 % 2 != 0)
                {
                    return true;
                }
                else
                {
                    i /= 10;
                }
            }
            return false;
        }

        private static bool CheckSumOfDigitsIsDivisibleByEight(int i)
        {
            int sumOfDigits = 0;
            while (i > 0)
            {
                sumOfDigits += i % 10;
                i /= 10;
            }
            if (sumOfDigits % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
