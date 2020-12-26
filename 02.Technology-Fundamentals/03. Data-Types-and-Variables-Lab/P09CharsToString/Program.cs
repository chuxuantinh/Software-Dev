using System;

namespace P09CharsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());
            string combine = "" + firstChar + secondChar + thirdChar;
            Console.WriteLine(combine);
        }
    }
}
