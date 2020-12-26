using System;

namespace example1
{
    class Program
    {
        public delegate void Print(int x);
        static void Main(string[] args)
        {
            Print printNumber = PrintNumber;
            printNumber(12);

            Print printString = PrintNumberAsString;
            printString(12);

        }

        static void PrintNumber(int x)
        {
            Console.WriteLine(x + 1);
        }

        static void PrintNumberAsString(int x)
        {
            Console.WriteLine($"{x} - string");
        }
    }
}
