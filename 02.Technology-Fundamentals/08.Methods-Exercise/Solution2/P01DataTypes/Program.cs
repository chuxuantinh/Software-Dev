using System;

namespace P01DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            if (dataType == "int")
            {
                int input = int.Parse(Console.ReadLine());
                Print(dataType, input);
            }
            else if (dataType == "real")
            {
                double input = double.Parse(Console.ReadLine());
                Print(dataType, input);
            }
            else if (dataType == "string")
            {
                string input = Console.ReadLine();
                Print(dataType, input);
            }
            
        }

        private static void Print(string dataType, int input)
        {
            Console.WriteLine(input * 2);
        }

        private static void Print(string dataType, double input)
        {
            Console.WriteLine($"{input * 1.5:f2}");
        }

        private static void Print(string dataType, string input)
        {
            Console.WriteLine($"${input}$");
        }
    }
}
