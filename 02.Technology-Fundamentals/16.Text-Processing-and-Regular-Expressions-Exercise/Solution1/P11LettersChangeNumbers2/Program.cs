using System;
using System.Linq;

namespace _08.Letters_Change_Numbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var sum = 0.0M;

            for (int i = 0; i < text.Length; i++)
            {
                var newString = text[i].ToString();
                var number = decimal.Parse(newString.Substring(1, newString.Length - 2));

                var firstLetter = newString[0];
                var lastLetter = newString[newString.Length - 1];

                var upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXZ".ToCharArray();
                var lowerCase = "abcdefghijklmnopqrstuvwxz".ToCharArray();

                if (firstLetter < 'a' - 1)//<96
                {
                    decimal divisor = firstLetter - 'A' + 1;
                    sum += number / divisor;
                }
                else
                {
                    decimal multiplier = firstLetter - 'a' + 1;
                    sum += number * multiplier;
                }

                if (lowerCase.Contains(lastLetter))
                {
                    decimal addNumber = lastLetter - 'a' + 1;
                    sum += addNumber;
                }
                else
                {
                    decimal substractNumber = lastLetter - 'A' + 1;
                    sum -= substractNumber;
                }
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}