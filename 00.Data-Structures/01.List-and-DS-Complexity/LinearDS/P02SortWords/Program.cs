using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02SortWords
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();

            words.Sort();

            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }
        }
    }
}
