using System;

namespace P02EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a1 = ReadNumber(1, 100);
                int a2 = ReadNumber(a1, 100);
                int a3 = ReadNumber(a2, 100);
                int a4 = ReadNumber(a3, 100);
                int a5 = ReadNumber(a4, 100);
                int a6 = ReadNumber(a5, 100);
                int a7 = ReadNumber(a6, 100);
                int a8 = ReadNumber(a7, 100);
                int a9 = ReadNumber(a8, 100);
                int a10 = ReadNumber(a9, 100);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        public static int ReadNumber(int start, int end)
        {
            int number = 0;
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid number");
            }
            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException("number","Number is out of range");
            }
            return number;
        }
    }
}
