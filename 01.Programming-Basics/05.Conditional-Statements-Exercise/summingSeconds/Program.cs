using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summingSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int competitor1Sec = int.Parse(Console.ReadLine());
            int competitor2Sec = int.Parse(Console.ReadLine());
            int competitor3Sec = int.Parse(Console.ReadLine());

            int sumSec = competitor1Sec + competitor2Sec + competitor3Sec;

            int min = sumSec / 60;
            int sec = sumSec % 60;
            if (sec < 10)
            {
                Console.WriteLine(min + ":0" + sec);
            }
            else
            {
                Console.WriteLine(min + ":" + sec);
            }

        }
    }
}
