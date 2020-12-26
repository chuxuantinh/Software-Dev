using System;
using System.Linq;

namespace _02.Sum_To_13
{
    internal class Program
    {
        private static void Main()
        {
            const int targetNumber = 13;

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (numbers[0] + numbers[1] + numbers[2] == targetNumber ||
                numbers[0] + numbers[1] - numbers[2] == targetNumber ||
                numbers[0] - numbers[1] + numbers[2] == targetNumber ||
                -numbers[0] + numbers[1] + numbers[2] == targetNumber ||
                numbers[0] - numbers[1] - numbers[2] == targetNumber ||
                -numbers[0] - numbers[1] + numbers[2] == targetNumber ||
                -numbers[0] + numbers[1] - numbers[2] == targetNumber ||
                -numbers[0] - numbers[1] - numbers[2] == targetNumber)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
