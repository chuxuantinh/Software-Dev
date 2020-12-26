using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            int numberStrings = int.Parse(Console.ReadLine());

            int[] numbers = new int[numberStrings];

            string vowels = "aAeEiIoOuU";
            char[] vowelsArr = vowels.ToCharArray();
            
            for (int i = 0; i < numberStrings; i++)
            {
                char[] letters = Console.ReadLine().ToCharArray();

                int sum = 0;
                for (int j = 0; j < letters.Length; j++)
                {
                    char currentChar = letters[j];
                    if (vowelsArr.Contains(currentChar))
                    {
                        sum += letters[j] * letters.Length;
                    }
                    else
                    {
                        sum += letters[j] / letters.Length;
                    }
                }
                numbers[i] = sum;
            }

            //Array.Sort(numbers);
            //int[] sorted = numbers.OrderBy(x => x).ToArray();

            for (int i = 0; i < numberStrings; i++)
            {
                for (int j = i + 1; j < numberStrings; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            foreach (var element in numbers)
            {
                Console.WriteLine($"{element}");
            }
        }
    }
}