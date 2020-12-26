using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] left = new int[input.Length / 4]; //left side
            int[] middle = new int[input.Length / 2]; //middle
            int[] right = new int[input.Length / 4]; // right side

            for (int i = 0; i < input.Length / 4; i++) // folding the left and the right side
            {
                left[i] = input[i];
                right[i] = input[i + 3 * (input.Length) / 4];
            }
            left = left.Reverse().ToArray();
            right = right.Reverse().ToArray();

            for (int i = 0; i < middle.Length; i++)  //middle section values
            {
                middle[i] = input[i + input.Length / 4];
            }

            for (int i = 0; i < middle.Length; i++) //calculation
            {
                if (i < middle.Length / 2)
                {
                    middle[i] = middle[i] + left[i]; //for the left side
                }
                else
                {
                    middle[i] = middle[i] + right[i - middle.Length / 2]; //for the right side
                }
            }

            Console.WriteLine(String.Join(" ", middle));
        }
    }
}