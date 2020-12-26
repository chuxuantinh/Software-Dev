using System;

namespace P04BackIn30MinutesTimeSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int totalMinutes = hours * 60 + minutes + 30;
            TimeSpan result = TimeSpan.FromMinutes(totalMinutes);
            string stringResult = result.ToString("h':'mm");
            Console.WriteLine(stringResult);
        }
    }
}
