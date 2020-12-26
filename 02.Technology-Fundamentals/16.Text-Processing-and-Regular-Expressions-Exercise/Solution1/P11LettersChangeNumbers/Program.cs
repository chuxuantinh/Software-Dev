using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LettersChangeNumbers
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ';' }; //add this ";" because the sequence starts from 0 and then on each row just add + 1
        char[] alphabetUpper = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ';' }; //add this ";" because the sequence starts from 0 and then on each row just add + 1
        List<decimal> wordResults = new List<decimal>();

        //main loop
        for (int i = 0; i < input.Length; i++)
        {
            string word = null; //reset the word
            word = input[i];
            string saveStringDigit = null; //save the digit as string
            decimal convertStringToDecimal = 0; // convert from string to decimal
            int indexOfAlphabetUpper = 0; // save the index of the letter in alphabet upper
            int indexOfAlphabetLower = 0; // save the index of the letter in alphabet lower
            int indexFirst = 0; // keep the first index of the word
            int indexLast = word.Length - 1; // keep the last index of the word

            //converting char to string , after that to decimal
            for (int j = 0; j < word.Length; j++)
            {
                if (char.IsDigit(word[j]))
                {
                    string saveDigit = word[j].ToString();
                    saveStringDigit += saveDigit;
                }
            }
            convertStringToDecimal = decimal.Parse(saveStringDigit);

            //check first index
            if (char.IsUpper(word[indexFirst]))
            {
                for (int j = 0; j < alphabetUpper.Length; j++)
                {
                    if (word[indexFirst].Equals(alphabetUpper[j]))
                    {
                        indexOfAlphabetUpper = Array.IndexOf(alphabetUpper, alphabetUpper[j + 1]);
                        convertStringToDecimal /= indexOfAlphabetUpper;
                    }
                }
            }

            //check first index
            if (char.IsLower(word[indexFirst]))
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (word[indexFirst].Equals(alphabet[j]))
                    {
                        indexOfAlphabetLower = Array.IndexOf(alphabet, alphabet[j + 1]);
                        convertStringToDecimal *= indexOfAlphabetLower;
                    }
                }
            }

            //check last index
            if (char.IsUpper(word[indexLast]))
            {
                for (int j = 0; j < alphabetUpper.Length; j++)
                {
                    if (word[indexLast].Equals(alphabetUpper[j]))
                    {
                        indexOfAlphabetUpper = Array.IndexOf(alphabetUpper, alphabetUpper[j + 1]);
                        convertStringToDecimal -= indexOfAlphabetUpper;
                    }
                }
            }

            //check last index
            if (char.IsLower(word[indexLast]))
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (word[indexLast].Equals(alphabet[j]))
                    {
                        indexOfAlphabetLower = Array.IndexOf(alphabet, alphabet[j + 1]);
                        convertStringToDecimal += indexOfAlphabetLower;
                    }
                }
            }

            //add the result in the list
            wordResults.Add(convertStringToDecimal);
        }

        //linq sum each value in the list and finally print it out
        decimal total = wordResults.Sum(x => x);
        Console.WriteLine($"{total:f2}");
    }
}