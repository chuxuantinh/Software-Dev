using System;
using System.Linq;

namespace P03ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] outputArr1 = new int[n];
            int[] outputArr2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < 2; j++)
                {
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    {
                        outputArr1[i] = arr[j];
                    }
                    else if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        outputArr2[i] = arr[j];
                    }
                }
            }
            foreach (int item in outputArr1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (int item in outputArr2)
            {
                Console.Write(item + " ");
            }
        }
    }
}
