﻿using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == String.Empty)
            {
                return;
            }

            int[] arr = input
                .Split()
                .Select(int.Parse)
                .ToArray();

            Mergesort<int>.Sort(arr);

            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
