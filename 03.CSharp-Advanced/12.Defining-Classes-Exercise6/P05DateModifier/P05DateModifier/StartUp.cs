using System;

namespace P05DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            Console.WriteLine(DateModifier.CalculateDays(date1, date2)); 
        }
    }
}
