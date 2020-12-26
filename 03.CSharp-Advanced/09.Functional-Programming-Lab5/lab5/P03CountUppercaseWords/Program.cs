using System;
using System.Linq;

namespace P02SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
              .Split(new char[] { ' ', }, StringSplitOptions.RemoveEmptyEntries)
              .Where(checker)
              .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        public static Func<string, bool> checker = n => n[0] == n.ToUpper()[0];
    }
}
