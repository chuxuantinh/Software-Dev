﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    for (int k = 1; k < 10; k++)
                    {
                        for (int l = 1; l < 10; l++)
                        {
                            for (int m = 1; m < 10; m++)
                            {
                                for (int n = 1; n < 10; n++)
                                {
                                    if (i * j * k * l * m * n == num)
                                    {
                                        Console.Write($"{i}{j}{k}{l}{m}{n} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}