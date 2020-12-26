using System;

namespace P03LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());
            PrintLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        private static void PrintLongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double length1 = Math.Sqrt(Math.Abs(x1 - x2) * Math.Abs(x1 - x2) + Math.Abs(y1 - y2) * Math.Abs(y1 - y2));
            double length2 = Math.Sqrt(Math.Abs(x3 - x4) * Math.Abs(x3 - x4) + Math.Abs(y3 - y4) * Math.Abs(y3 - y4));
            if (length1 >= length2)
            {
                PrintLineWithClosestPointFirst(x1, y1, x2, y2);
            }
            else
            {
                PrintLineWithClosestPointFirst(x3, y3, x4, y4);
            }
        }

        private static void PrintLineWithClosestPointFirst(double x1, double y1, double x2, double y2)
        {
            double distance1 = Math.Sqrt(Math.Abs(x1) * Math.Abs(x1) + Math.Abs(y1) * Math.Abs(y1));
            double distance2 = Math.Sqrt(Math.Abs(x2) * Math.Abs(x2) + Math.Abs(y2) * Math.Abs(y2));
            if (distance1 <= distance2)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }

    }
}
