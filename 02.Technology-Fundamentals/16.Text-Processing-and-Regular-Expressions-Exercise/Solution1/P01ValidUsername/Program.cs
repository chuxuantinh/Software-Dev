using System;
using System.Collections.Generic;

namespace P01ValidUsername
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ");
            
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                bool isValid = false;
                if (word.Length >= 3 && word.Length <= 16)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        char currentCharacter = word[j];
                        if (char.IsLetterOrDigit(currentCharacter) || currentCharacter == '-' || currentCharacter == '_')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
