using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());
            int stops = int.Parse(Console.ReadLine());
            for (int i = 1; i <= stops; i++)
            {
                int off = int.Parse(Console.ReadLine());
                int on = int.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    passengers = passengers - off + on + 2;
                }
                else
                {
                    passengers = passengers - off + on - 2;
                }
            }
            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
