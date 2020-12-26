using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int minutesPlus15 = minutes + 15;

            if (minutesPlus15 > 59)
            {
                hour++;
                minutesPlus15 -= 60;
            }
            if (hour > 23)
            {
                hour = hour - 24;
            }
            if (minutesPlus15 < 10)
            {
                Console.WriteLine("{0}:0{1}", hour, minutesPlus15);
            }
            else
            {
                Console.WriteLine("{0}:{1}", hour, minutesPlus15);
            }
        }
    }
}
