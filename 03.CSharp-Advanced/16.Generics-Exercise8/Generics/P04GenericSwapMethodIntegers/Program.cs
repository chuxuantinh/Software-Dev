using System;
using System.Linq;

namespace P01GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<int> myBox = new Box<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());

                myBox.Add(input);
            }

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            myBox.Swap(firstIndex, secondIndex);

            string result = myBox.ToString();

            Console.WriteLine(result);
        }
    }
}
