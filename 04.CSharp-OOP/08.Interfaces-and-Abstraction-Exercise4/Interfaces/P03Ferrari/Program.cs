using P03Ferrari.Models;
using System;

namespace P03Ferrari
{
    public class Program
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            Ferrari ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}
