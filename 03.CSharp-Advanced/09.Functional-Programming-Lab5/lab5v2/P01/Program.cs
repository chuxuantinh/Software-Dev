using System;

namespace P01
{
    class Program
    {
        public delegate string BinaryOperator(int x, int y);
        static void Main(string[] args)
        {
            BinaryOperator opMulti = Multiply;
            Console.WriteLine(Calculator(4, 5, Multiply));
            Console.WriteLine(Calculator(4, 5, Add));
            Console.WriteLine(Calculator(4, 5, IsGreater));
        }

        public static string Calculator(int x, int y, BinaryOperator opr)
        {
            return opr(x, y);
        }

        public static string Multiply(int x, int y)
        {
            return (x * y).ToString();
        }

        public static string Add(int x, int y)
        {
            return (x + y).ToString();
        }

        public static string IsGreater(int x, int y)
        {
            return (x > y).ToString();
        }
    }
}
