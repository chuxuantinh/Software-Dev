using System;

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

            string result = myBox.ToString();

            Console.WriteLine(result);
        }
    }
}
