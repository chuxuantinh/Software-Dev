using System;
using System.Linq;

namespace opit2
{
    class Program
    {
        static int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "end")
            {
                Console.WriteLine("neshto");
            }
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
