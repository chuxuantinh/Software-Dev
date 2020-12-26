using System;

namespace P10PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            int newN = N;
            int count = 0;
            while (newN >= M)
            {
                newN -= M;
                count++;
                if (newN == 0.5 * N && Y != 0)
                {
                    newN /= Y;
                }
            }
            Console.WriteLine($"{newN}");
            Console.WriteLine(count);
        }
    }
}
