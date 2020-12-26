using System;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, string> opMulti = Multiply;
            Console.WriteLine(Calculator(4, 5, Multiply));
            Console.WriteLine(Calculator(4, 5, Add));
            Console.WriteLine(Calculator(4, 5, IsGreater));
            Console.WriteLine(Calculator(21, 3, (x, y) => (x / y).ToString()));
        }

        public static string Calculator(int x, int y, Func<int, int, string> opr)
        {
            return opr(x, y);
        }

        public static string Multiply(int x, int y) => (x * y).ToString();
       
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
