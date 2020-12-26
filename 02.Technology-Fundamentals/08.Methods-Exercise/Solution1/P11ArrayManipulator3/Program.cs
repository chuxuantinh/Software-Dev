using System;

namespace P11ArrayManipulator3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void ExchangeCommand(int[] array, int inputNumber)
        {
            for (int i = 0; i <= inputNumber; i++)
            {
                int firstNumber = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = firstNumber;
            }
        }
    }
}
