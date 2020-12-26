using System;

class Program
{
    public static int fibonacciLoop(int nthNumber)
    {
        int previouspreviousNumber, previousNumber = 0, currentNumber = 1;

        for (int i = 1; i < nthNumber; i++)
        {
            previouspreviousNumber = previousNumber;

            previousNumber = currentNumber;

            currentNumber = previouspreviousNumber + previousNumber;

        }

        return currentNumber;
    }

    static void Main(string[] args)
    {
        int nthNumber = int.Parse(Console.ReadLine());
        Console.WriteLine(fibonacciLoop(nthNumber));
    }
}
