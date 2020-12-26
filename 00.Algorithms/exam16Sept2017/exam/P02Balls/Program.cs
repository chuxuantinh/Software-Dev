using System;
using System.Text;

namespace P02Balls
{
    class Program
    {
        static int[] result;
        static int pockets;
        static int capacity;
        static StringBuilder builder = new StringBuilder();

        static void Generate(int index, int ballsLeft)
        {
            if (index == pockets)
            {
                if (ballsLeft == 0)
                {
                    builder.AppendLine(string.Join(", ", result));
                }
                
                return;
            }

            var ballsToPut = ballsLeft - (pockets - (index + 1));

            if (ballsToPut > capacity)
            {
                ballsToPut = capacity;
            }

            for (int i = ballsToPut; i > 0; i--)
            {
                result[index] = i;
                Generate(index + 1, ballsLeft - i);
            }
        }

        static void Main(string[] args)
        {
            pockets = int.Parse(Console.ReadLine());
            var balls = int.Parse(Console.ReadLine());
            capacity = int.Parse(Console.ReadLine());

            result = new int[pockets];

            Generate(0, balls);

            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
