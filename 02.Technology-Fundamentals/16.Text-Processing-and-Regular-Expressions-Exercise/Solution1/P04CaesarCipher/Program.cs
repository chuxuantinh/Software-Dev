using System;
using System.Text;

namespace P04CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (var symbol in input)
            {
                char encryptedSymbol = (char)(symbol + 3);
                sb.Append(encryptedSymbol);
            }
            Console.WriteLine(sb);
        }
    }
}
