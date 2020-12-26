using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 700;
            while (capacity > 0)
            {
                capacity -= 200;
                Console.WriteLine("Drink more!");
            }
            Console.WriteLine("Go ...");
        }
    }
}
