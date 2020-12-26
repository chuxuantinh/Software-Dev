using System;
using System.Text;

namespace _02.Parentheses
{
    internal class Program
    {
        private static readonly StringBuilder Result = new StringBuilder();

        public static void Main()
        {
            var pairs = int.Parse(Console.ReadLine());

            var output = new char[2 * pairs];

            output[0] = '(';
            output[1] = ')';

            BracketsBuilder(output, 1, pairs - 1, pairs, pairs);

            Console.Write(Result.ToString());
        }

        public static void BracketsBuilder(char[] output, int index, int open, int close, int pairs)
        {
            while (true)
            {
                if (index == 2 * pairs)
                {
                    Result.AppendLine(string.Join("", output));

                    return;
                }

                if (open != 0)
                {
                    output[index] = '(';

                    BracketsBuilder(output, index + 1, open - 1, close, pairs);
                }

                if (close == 0 || pairs - close + 1 > pairs - open)
                {
                    return;
                }

                output[index] = ')';

                index = index + 1;
                close = close - 1;
            }
        }
    }
}