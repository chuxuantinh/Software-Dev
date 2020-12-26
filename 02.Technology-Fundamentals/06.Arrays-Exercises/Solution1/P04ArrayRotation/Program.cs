using System;
using System.Linq;

namespace P04ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < rotations; i++)
            {
                int firstNumber = myArray[0];
                for (int j = 0; j < myArray.Length - 1; j++)
                {
                    myArray[j] = myArray[j + 1];
                }
                myArray[myArray.Length - 1] = firstNumber;
            }
            Console.WriteLine(String.Join(" ", myArray));
        }
    }
}
