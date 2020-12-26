using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int[] price;
    static int[] bestPrice;
    static int[] bestCombo;

    static void Main(string[] args)
    {
        price = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        bestPrice = new int[price.Length];
        bestCombo = new int[price.Length];

        int n = int.Parse(Console.ReadLine());

        int totalBest = CutRod(n);

        List<int> result = new List<int>();

        while (n > 0)
        {
            int next = bestCombo[n];
            result.Add(next);
            n -= next;
        }

        Console.WriteLine(totalBest);
        Console.WriteLine(String.Join(" ", result));
    }

    private static int CutRod(int n)
    {
        if (bestPrice[n] > 0) return bestPrice[n];
        if (n == 0) return 0;
        var currentBest = bestPrice[n];
        for (int i = 1; i <= n; i++)
        {
            currentBest =
                Math.Max(currentBest, price[i] + CutRod(n - i));
            if (currentBest > bestPrice[n])
            {
                bestPrice[n] = currentBest; bestCombo[n] = i;
            }
        }
        return bestPrice[n];
    }
}
