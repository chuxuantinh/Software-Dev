﻿using System;
using System.Linq;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main()
        {
            int[] firstArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = firstArray.Length / 4;

            // Creation of the third array

            int[] thirdFoldedArray = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                thirdFoldedArray[i] = firstArray[k - 1 - i];
                thirdFoldedArray[k + i] = firstArray[4 * k - 1 - i];
            }

            // Creation of the second/middle array and direct printing -> no result/sum array needed

            int[] secondArray = new int[2 * k];

            for (int i = 0; i < 2 * k; i++)
            {
                secondArray[i] = firstArray[i + k];
                Console.Write($"{thirdFoldedArray[i] + secondArray[i]} ");
            }

            Console.WriteLine();
        }
    }
}