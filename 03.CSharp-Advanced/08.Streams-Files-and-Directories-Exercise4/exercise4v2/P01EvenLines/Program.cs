using System;
using System.IO;
using System.Linq;

namespace P01EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"text.txt";
            string outputFilePath = @"output.txt";
            int counter = 0;
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader streamReader = new StreamReader(textFilePath))
                {
                    string currentLine = streamReader.ReadLine();
                    while (currentLine != null)
                    {
                        if (counter % 2 == 0)
                        {
                            string replacedSymbols = ReplaceSpecialCharacters(currentLine);
                            string reversedWords = ReverseWords(replacedSymbols);
                            writer.WriteLine(reversedWords);
                        }
                        currentLine = streamReader.ReadLine();

                        counter++;
                    }
                }
            }
            

        }

        private static string ReverseWords(string replacedSymbols)
        {
            return string.Join(" ", replacedSymbols.Split().Reverse());
        }

        private static string ReplaceSpecialCharacters(string currentLine)
        {
            return currentLine.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@");
        }
    }
}
