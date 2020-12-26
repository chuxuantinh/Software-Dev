using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= 800)
                {
                    p5++;
                }
                else if (num >= 600)
                {
                    p4++;
                }
                else if (num >= 400)
                {
                    p3++;
                }
                else if (num >= 200)
                {
                    p2++;
                }
                else if (num >= 1)
                {
                    p1++;
                }
            }
            Console.WriteLine($"{(p1 * 100.0 / n):f2}%");
            Console.WriteLine($"{(p2 * 100.0 / n):f2}%");
            Console.WriteLine($"{(p3 * 100.0 / n):f2}%");
            Console.WriteLine($"{(p4 * 100.0 / n):f2}%");
            Console.WriteLine($"{(p5 * 100.0 / n):f2}%");
        }
    }
}
