﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var dp = new int[numbers.Length, 2];
        var prev = new int[numbers.Length, 2];
        dp[0, 0] = dp[0, 1] = 1;
        prev[0, 0] = prev[0, 1] = -1;
        var maxResult = 0;
        var maxIndexRow = 0;
        var maxIndexCol = 0;

        for (int currentIndex = 1; currentIndex < numbers.Length; currentIndex++)
        {
            for (int prevIndex = 0; prevIndex < currentIndex; prevIndex++)
            {
                var currentNumber = numbers[currentIndex];
                var prevNumber = numbers[prevIndex];

                if (currentNumber > prevNumber &&
                    dp[currentIndex, 0] < dp[prevIndex, 1] + 1)
                {
                    dp[currentIndex, 0] = dp[prevIndex, 1] + 1;
                    prev[currentIndex, 0] = prevIndex;
                }

                if (currentNumber < prevNumber &&
                    dp[currentIndex, 1] < dp[prevIndex, 0] + 1)
                {
                    dp[currentIndex, 1] = dp[prevIndex, 0] + 1;
                    prev[currentIndex, 1] = prevIndex;
                }
            }

            if (dp[currentIndex, 0] > maxResult)
            {
                maxResult = dp[currentIndex, 0];
                maxIndexRow = currentIndex;
                maxIndexCol = 0;
            }

            if (dp[currentIndex, 1] > maxResult)
            {
                maxResult = dp[currentIndex, 1];
                maxIndexRow = currentIndex;
                maxIndexCol = 1;
            }
        }

        var result = new List<int>();

        while (maxIndexRow >= 0)
        {
            result.Add(numbers[maxIndexRow]);

            maxIndexRow = prev[maxIndexRow, maxIndexCol];

            if (maxIndexCol == 1)
            {
                maxIndexCol = 0;
            }
            else
            {
                maxIndexCol = 1;
            }
        }

        result.Reverse();

        Console.WriteLine(string.Join(" ", result));
    }
}
