namespace _09.Rage_Quit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine().ToUpper();
            int repeatNumber = 0;

            StringBuilder repeatedString = new StringBuilder();
            StringBuilder result = new StringBuilder();
            StringBuilder uniqueSymbols = new StringBuilder();

            for (int i = 0; i < input.Length - 1; i++)
            {
                char currentChar = input[i];
                char nextChar = input[i + 1];
                if (!char.IsDigit(currentChar))
                {
                    repeatedString.Append(currentChar.ToString());

                }

                if (i == input.Length - 2 && !char.IsDigit(currentChar))
                {
                    repeatNumber = int.Parse(nextChar.ToString());
                    AddToFinalString(repeatNumber, result, repeatedString, uniqueSymbols);

                }
                else if (char.IsDigit(currentChar) && char.IsDigit(nextChar))
                {
                    string repeat = currentChar.ToString() + nextChar.ToString();
                    repeatNumber = int.Parse(repeat);
                    AddToFinalString(repeatNumber, result, repeatedString, uniqueSymbols);

                }
                else if (char.IsDigit(currentChar))
                {
                    repeatNumber = int.Parse(currentChar.ToString());
                    AddToFinalString(repeatNumber, result, repeatedString, uniqueSymbols);
                }



            }

            List<char> uniqueSymbol = new List<char>();


            for (int i = 0; i < uniqueSymbols.Length; i++)
            {
                char uniqueChar = uniqueSymbols[i];
                if (!uniqueSymbol.Contains(uniqueChar) && !char.IsDigit(uniqueChar))
                {
                    uniqueSymbol.Add(uniqueChar);
                }
            }



            Console.WriteLine($"Unique symbols used: {uniqueSymbol.Count}");
            Console.WriteLine(result);


        }
        public static void AddToFinalString(int repeatNumber, StringBuilder result, StringBuilder repeatedString, StringBuilder uniqueSymbols)
        {
            for (int j = 0; j < repeatNumber; j++)
            {
                result.Append(repeatedString.ToString());
            }
            if (repeatNumber != 0)
            {
                uniqueSymbols.Append(repeatedString.ToString());
            }
            repeatedString.Clear();


        }
    }
}