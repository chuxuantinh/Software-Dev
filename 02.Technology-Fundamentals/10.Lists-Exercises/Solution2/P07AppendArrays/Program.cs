using System;
using System.Collections.Generic;
using System.Linq;

namespace P07AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> array = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> result = array[array.Count - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (array.Count == 1)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                for (int i = array.Count - 2; i >= 0; i--)
                {
                    List<string> subarray = array[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                    result.AddRange(subarray);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
