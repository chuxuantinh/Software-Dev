﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rowNumbers2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 1;
            while (k <= n)
            {
                Console.WriteLine(k);
                k = 2 * k + 1;
            }
        }
    }
}
