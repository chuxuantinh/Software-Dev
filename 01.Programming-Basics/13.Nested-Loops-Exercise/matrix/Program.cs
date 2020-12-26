using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int n1 = a; n1 <= b; n1++)
            {
                for (int n2 = a; n2 <= b; n2++)
                {
                    for (int n3 = c; n3 <= d; n3++)
                    {
                        for (int n4 = c; n4 <= d; n4++)
                        {
                            if (n1 != n2 && n3 != n4 && n1 + n4 == n2 + n3)
                            {
                                Console.WriteLine($"{n1}{n2}");
                                Console.WriteLine($"{n3}{n4}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
