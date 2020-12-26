using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equalPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentSum = 0;
            int previousSum = 0;
            int maxDiff = 0;
            int currentDiff = 0;
            for (int i = 0; i < n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                currentSum = num1 + num2;
                if (previousSum != 0)
                {
                    currentDiff = Math.Abs(currentSum - previousSum);
                    if (currentDiff > maxDiff)
                    {
                        maxDiff = currentDiff;
                    }
                }
                previousSum = currentSum;
            }
            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={currentSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
