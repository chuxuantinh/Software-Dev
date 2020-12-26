using System;

namespace P07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split();

            Predicate<string> isShorter = name => name.Length <= number;

            foreach (var name in names)
            {
                if (isShorter(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
