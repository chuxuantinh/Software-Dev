using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08_LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            Dictionary<char, byte> alphabet = new Dictionary<char, byte>();
            byte position = 1;
            for (byte i = 65; i <= 90; i++)
            {
                alphabet.Add((char)i, position);
                position++;
            }
            decimal sum = 0.0m;
            string pattern = @"([^\d]?)([\d]+)([^\d]?)";
            Regex regex = new Regex(pattern);
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                Match matc = regex.Match(input[i]);
                if (matc.Groups[1].ToString() == matc.Groups[1].ToString().ToUpper())
                {
                    decimal n = decimal.Parse(matc.Groups[2].ToString());
                    sum += n / alphabet[char.Parse(matc.Groups[1].ToString().ToUpper())];
                    if (matc.Groups[3].ToString() == matc.Groups[3].ToString().ToUpper())
                    {
                        sum -= alphabet[char.Parse(matc.Groups[3].ToString().ToUpper())];
                    }
                    else
                    {
                        sum += alphabet[char.Parse(matc.Groups[3].ToString().ToUpper())];
                    }
                }
                else
                {
                    decimal n = decimal.Parse(matc.Groups[2].ToString());
                    sum += n * alphabet[char.Parse(matc.Groups[1].ToString().ToUpper())];
                    if (matc.Groups[3].ToString() == matc.Groups[3].ToString().ToUpper())
                    {
                        sum -= alphabet[char.Parse(matc.Groups[3].ToString().ToUpper())];
                    }
                    else
                    {
                        sum += alphabet[char.Parse(matc.Groups[3].ToString().ToUpper())];
                    }
                }
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}