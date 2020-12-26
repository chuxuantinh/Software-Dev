using System;
using System.Collections.Generic;
using System.Linq;

namespace P03FinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "Delete")
                {
                    int index = int.Parse(tokens[1]);
                    if (index + 1 < words.Count && index >= -1)
                    {
                        words.RemoveAt(index + 1);
                    }

                }
                else if (tokens[0] == "Swap")
                {
                    string word1 = tokens[1];
                    string word2 = tokens[2];
                    if (words.Contains(word1) && words.Contains(word2))
                    {
                        int index1 = words.IndexOf(word1);
                        int index2 = words.IndexOf(word2);
                        string temp = word1;
                        words[index1] = word2;
                        words[index2] = temp;
                    }
                }
                else if (tokens[0] == "Put")
                {
                    string word = tokens[1];
                    int index = int.Parse(tokens[2]);
                    if (index - 1 >= 0 && index <= words.Count)
                    {
                        words.Insert(index - 1, word);
                    }
                    
                }
                else if (tokens[0] == "Sort")
                {
                    words.Sort();
                    words.Reverse();
                }
                else if (tokens[0] == "Replace")
                {
                    string word1 = tokens[1];
                    string word2 = tokens[2];
                    if (words.Contains(word2))
                    {
                        int index = words.IndexOf(word2);
                        words[index] = word1;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
