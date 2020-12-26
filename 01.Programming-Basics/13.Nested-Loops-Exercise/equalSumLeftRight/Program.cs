using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equalSumLeftRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            int middle = 0;
            for (int i = n; i <= m; i++)
            {
                leftSum = 0;
                rightSum = 0;
                int k = i;
                rightSum += k % 10;
                k = k - k % 10;
                k = k / 10;
                rightSum += k % 10;
                k = k - k % 10;
                k = k / 10;
                middle = k % 10;
                k = k - k % 10;
                k = k / 10;
                leftSum += k % 10;
                k = k - k % 10;
                k = k / 10;
                leftSum += k % 10;
                if (leftSum == rightSum)
                {
                    Console.Write($"{i} ");
                }
                else if (leftSum < rightSum)
                {
                    leftSum += middle;
                    if (leftSum == rightSum)
                    {
                        Console.Write($"{i} ");
                    }
                }
                else if (leftSum > rightSum)
                {
                    rightSum += middle;
                    if (leftSum == rightSum)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
        }
    }
}
