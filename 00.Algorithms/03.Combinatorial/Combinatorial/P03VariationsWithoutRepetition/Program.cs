using System;
using System.Linq;

class Program
{
    static char[] set;
    static char[] variation;
    static bool[] used;

    static void Main(string[] args)
    {
        set = Console.ReadLine()
            .Split()
            .Select(Char.Parse)
            .ToArray();

        int k = int.Parse(Console.ReadLine());

        variation = new char[k];
        used = new bool[set.Length];

        Variate(0);
    }

    private static void Variate(int index)
    {
        if (index >= variation.Length)
        {
            Console.WriteLine(string.Join(" ", variation));
        }
        else
        {
            for (int i = 0; i < set.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variation[index] = set[i];
                    Variate(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
