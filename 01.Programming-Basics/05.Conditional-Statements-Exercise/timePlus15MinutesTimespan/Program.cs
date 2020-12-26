using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timePlus15MinutesTimespan
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int hoursInMinutes = hours * 60;
            int totalMinutes = hoursInMinutes + minutes + 15;
            TimeSpan result = TimeSpan.FromMinutes(totalMinutes);
            string stringResult = result.ToString("h':'mm");
            Console.WriteLine(stringResult);
        }
    }
}
