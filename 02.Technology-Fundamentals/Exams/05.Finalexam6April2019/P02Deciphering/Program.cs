using System;
using System.Text;

namespace P02Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] wordsToReplace = Console.ReadLine().Split();
            string wordToRemove = wordsToReplace[0];
            string wordToInsert = wordsToReplace[1];
            StringBuilder sb = new StringBuilder(input);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 100 && input[i] <= 122 || input[i] == '{' || input[i] == '}' || input[i] == '|' || input[i] == '#')
                {
                    sb[i] = (char)(input[i] - 3);
                }
                else
                {
                    Console.WriteLine("This is not the book you are looking for.");
                    return;
                }
            }
            string result = sb.ToString();
            while (result.Contains(wordToRemove))
            {
                result = result.Replace(wordToRemove, wordToInsert);
            }
            Console.WriteLine(result);
        }
    }
}
