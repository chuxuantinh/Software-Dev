using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string wordsFileName = "words.txt";
            string textFileName = "text.txt";
            string outputFile = "Output.txt";
            string wordsFilePath = Path.Combine(path, wordsFileName);
            string textFilePath = Path.Combine(path, textFileName);
            using (var wordsReader = new StreamReader(wordsFilePath))
            {
                using (var textReader = new StreamReader(textFilePath))
                {
                    Dictionary<string, int> dict = new Dictionary<string, int>();
                    string[] words = wordsReader.ReadLine().Split();
                    string[] text = textReader.ReadToEnd().Split(new char[] { ' ',  '\n'  });
                    for (int i = 0; i < words.Length; i++)
                    {
                        dict.Add(words[i].ToLower(), 0);
                        for (int j = 0; j < text.Length; j++)
                        {
                            if (text[j].ToLower().Contains(words[i]))
                            {
                                dict[words[i]]++;
                            }
                        }
                    }
                    using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                    {
                        foreach (var kvp in dict.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                        }
                    }
                }
                
            }
        }
    }
}
