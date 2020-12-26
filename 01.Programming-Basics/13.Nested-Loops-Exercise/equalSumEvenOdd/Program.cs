using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equalSumEvenOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;
            for (int i = n; i <= m; i++)
            {
                evenSum = 0;
                oddSum = 0;
                int k = i;
                evenSum += k % 10;
                k = k - k % 10;
                k = k / 10;
                oddSum += k % 10;
                k = k - k % 10;
                k = k / 10;
                evenSum += k % 10;
                k = k - k % 10;
                k = k / 10;
                oddSum += k % 10;
                k = k - k % 10;
                k = k / 10;
                evenSum += k % 10;
                k = k - k % 10;
                k = k / 10;
                oddSum += k % 10;
                
                if (evenSum == oddSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
