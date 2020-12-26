using System;

namespace P01BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bitToFind = int.Parse(Console.ReadLine());

            string binary = Convert.ToString(number, 2);
            //string number = "100";
            //int fromBase = 16;
            //int toBase = 10;
            //string result = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);

            int counter = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] - '0' == bitToFind)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
