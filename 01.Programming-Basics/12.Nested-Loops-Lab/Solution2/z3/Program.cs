using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int n = 0; n <= num; n+=2)
            {
                Console.WriteLine(Math.Pow(2, n));
            }
        }
    }
}
