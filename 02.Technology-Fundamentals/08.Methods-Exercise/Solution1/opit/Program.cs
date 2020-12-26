using System;

namespace opit
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] a = { '1', '2', '1' };
            char[] b = { '1', '2', '1' };
            if (a == b)
            {
                Console.WriteLine("true");
            }
            string opit = "asdf";
            Console.WriteLine($"{opit[0]}");
        }
    }
}
