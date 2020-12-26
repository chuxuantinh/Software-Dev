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
            char[] commandReversed = GetReversed(command);
            char[] commandToArray = command.ToCharArray();
            for (int i = 0; i < commandToArray.Length; i++)
            {
                if (commandToArray[i] != commandReversed[i])
                {
                    return false;
                }
            }
            
            return true;
            
        }

        private static char[] GetReversed(string command)
        {
            char[] commandReversed = command.ToCharArray();
            Array.Reverse(commandReversed);
            return commandReversed;
            
        }
    }
}
