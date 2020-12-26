using System;
using System.Linq;

namespace P01GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<double> myBox = new Box<double>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());

                myBox.Add(input);
            }

            double doubleToCompare = double.Parse(Console.ReadLine());

            myBox.Compare(doubleToCompare);

            int result = myBox.CountGreater;

            Console.WriteLine(result);
        }
    }
}
