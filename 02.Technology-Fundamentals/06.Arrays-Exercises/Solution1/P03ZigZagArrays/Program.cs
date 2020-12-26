using System;
using System.Linq;

namespace P03ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArrays = int.Parse(Console.ReadLine());
            int[] fromLeftDiagonal = new int[numberOfArrays];
            int[] fromRightDiagonal = new int[numberOfArrays];

            for (int i = 0; i < numberOfArrays; i++)
            {
                int[] currentArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    fromLeftDiagonal[i] = currentArray[0];
                    fromRightDiagonal[i] = currentArray[1];
                }
                else
                {
                    fromLeftDiagonal[i] = currentArray[1];
                    fromRightDiagonal[i] = currentArray[0];
                }

            }

            Console.WriteLine(String.Join(" ", fromLeftDiagonal));
            Console.WriteLine(String.Join(" ", fromRightDiagonal));
        }
    }
}
