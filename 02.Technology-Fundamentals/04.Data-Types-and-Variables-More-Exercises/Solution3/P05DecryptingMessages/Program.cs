using System;

namespace P05DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            string result = string.Empty;
            for (int i = 0; i < m; i++)
            {
                char character = char.Parse(Console.ReadLine());
                result += (char)(character + n);
            }
            Console.WriteLine(result);
        }
    }
}
