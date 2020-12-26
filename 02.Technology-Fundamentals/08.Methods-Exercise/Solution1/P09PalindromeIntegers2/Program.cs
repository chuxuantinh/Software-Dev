using System;

namespace P09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {

                bool isPalindrome = CheckPalindrome(command);
                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                command = Console.ReadLine();
            }
        }

        private static bool CheckPalindrome(string command)
        {
            string commandReversed = GetReversed(command);
            int compare = string.Compare(command, commandReversed);
            if (compare == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static string GetReversed(string command)
        {
            char[] commandReversed = command.ToCharArray();
            Array.Reverse(commandReversed);
            string commandReversedToString = new string(commandReversed);
            return commandReversedToString;

        }
    }
}
