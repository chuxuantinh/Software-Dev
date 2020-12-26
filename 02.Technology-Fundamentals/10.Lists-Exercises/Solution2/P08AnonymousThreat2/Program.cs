using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();

            while (true)
            {
                string Data = Console.ReadLine();

                if (Data == "3:1")
                {
                    break;
                }
                string[] SplittedData = Data.Split(' ').ToArray();
                string command = SplittedData[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(SplittedData[1]);
                    int endIndex = int.Parse(SplittedData[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex > input.Count - 1)
                    {
                        startIndex = input.Count - 1;
                    }
                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    else if (endIndex > input.Count - 1)
                    {
                        endIndex = input.Count - 1;
                    }

                    StringBuilder concatWords = new StringBuilder();
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatWords.Append(input[i]);
                    }
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        input.RemoveAt(startIndex);
                    }
                    input.Insert(startIndex, concatWords.ToString());
                }
                if (command == "divide")
                {
                    List<string> adding = new List<string>();
                    int startIndex = int.Parse(SplittedData[1]);
                    int parts = int.Parse(SplittedData[2]);

                    string startIndexWord = input[startIndex];
                    int lenghtOfSubstring = startIndexWord.Length / parts;

                    if (startIndexWord.Length % parts == 0)
                    {
                        for (int i = 0; i < parts; i++)
                        {
                            adding.Add(startIndexWord.Substring(0, lenghtOfSubstring));
                            startIndexWord = startIndexWord.Remove(0, lenghtOfSubstring);
                        }
                        input.RemoveAt(startIndex);
                        input.InsertRange(startIndex, adding);
                    }
                    else
                    {
                        parts--;
                        for (int i = 0; i < parts; i++)
                        {
                            adding.Add(startIndexWord.Substring(0, lenghtOfSubstring));
                            startIndexWord = startIndexWord.Remove(0, lenghtOfSubstring);
                        }
                        adding.Add(startIndexWord);
                        input.RemoveAt(startIndex);
                        input.InsertRange(startIndex, adding);

                    }
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}