using System;

namespace P05Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string output = "";
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number == 0)
                {
                    output += (char)32;
                    continue;
                }
                int digitsCount = 0;
                int mainDigit = number % 10;
                while (number > 0)
                {
                    number /= 10;
                    digitsCount++;
                }
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }
                int letterIndex = offset + digitsCount - 1;
                char letter = (char)('a' + letterIndex);
                output += letter;
            }
            Console.WriteLine(output);
        }
    }
}
