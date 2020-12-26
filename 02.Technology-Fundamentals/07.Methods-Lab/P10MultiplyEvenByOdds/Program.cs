using System;
class Program
{
    static void Main()
    {
        int num = Math.Abs(int.Parse(Console.ReadLine()));
        int result = FindResult(num);
        Console.WriteLine(result);
    }

    static int FindResult(int num)
    {
        int result = FindSumOfOdds(num) * FindSumOfEvens(num);
        return result;
    }

    static int FindSumOfOdds(int num)
    {
        int sumOfOdds = 0;

        while (num > 0)
        {

            int nextNum = num % 10;
            num /= 10;
            if (nextNum % 2 != 0)
            {
                sumOfOdds += nextNum;
            }

        }

        return sumOfOdds;
    }

    static int FindSumOfEvens(int num)
    {
        int sumOfEvens = 0;
        while (num > 0)
        {
            int nextNum = num % 10;
            num /= 10;
            if (nextNum % 2 == 0)
            {
                sumOfEvens += nextNum;
            }

        }

        return sumOfEvens;
    }
}