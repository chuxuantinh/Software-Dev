using System;

namespace P05ASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int index1 = int.Parse(Console.ReadLine());
            int index2 = int.Parse(Console.ReadLine());
            for (int i = index1; i <= index2; i++)
            {
                Console.Write((char)i+" ");
            }
        }
    }
}
