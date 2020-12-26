using System;
using System.Text;

namespace P07RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string result = RepeatString(str, n);
            Console.WriteLine(result);
        }

        private static string RepeatString(string str, int n)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                result.Append(str);
            }
            return result.ToString();
        }
    }
}
