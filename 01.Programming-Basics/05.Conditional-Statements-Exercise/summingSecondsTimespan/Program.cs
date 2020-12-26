using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summingSecondsTimespan
{
    class Program
    {
        static void Main(string[] args)
        {
            int competitor1Sec = int.Parse(Console.ReadLine());
            int competitor2Sec = int.Parse(Console.ReadLine());
            int competitor3Sec = int.Parse(Console.ReadLine());

            int sumSec = competitor1Sec + competitor2Sec + competitor3Sec;
            TimeSpan result = TimeSpan.FromSeconds(sumSec);
            string stringResult = result.ToString("m':'ss");
            Console.WriteLine(stringResult);
        }
    }
}
