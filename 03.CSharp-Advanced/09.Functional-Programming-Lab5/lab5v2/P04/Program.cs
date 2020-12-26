using System;
using System.Linq;

namespace P03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .Select(w =>
                {
                    Console.WriteLine(w);
                    return w;
                })
                .ToList();
        }
    }
}
