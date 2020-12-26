using System;

namespace uprazhnenie1more
{
    class Program
    {
        static void Main(string[] args)
        {
            double max = double.MinValue;
            double min = double.MaxValue;
            double num1 = double.Parse(Console.ReadLine());
            double middle = 0;
            if (num1 > max)
            {
                max = num1;
            }
            if (num1 < min)
            {
                min = num1;
            }
            
            double num2 = double.Parse(Console.ReadLine());
            
            if (num2 > max)
            {
                max = num2;
            }
            if (num2 < min)
            {
                min = num2;
            }
            
            double num3 = double.Parse(Console.ReadLine());
            
            if (num3 > max)
            {
                max = num3;
            }
            if (num3 < min)
            {
                min = num3;
            }
            if (max == num1 && min == num2)
            {
                middle = num3;
            }
            else if (max == num1 && min == num3)
            {
                middle = num2;
            }
            else if (max == num2 && min == num1)
            {
                middle = num3;
            }
            else if (max == num2 && min == num3)
            {
                middle = num1;
            }
            else if (max == num3 && min == num1)
            {
                middle = num2;
            }
            else if (max == num3 && min == num2)
            {
                middle = num1;
            }

            Console.WriteLine(max);
            Console.WriteLine(middle);
            Console.WriteLine(min);
        }
    }
}
