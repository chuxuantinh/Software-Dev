﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P01ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    if (command.Contains("Create"))
                    {
                        List<string> items = command.Split().Skip(1).ToList();
                        listyIterator = new ListyIterator<string>(items);
                    }
                    else if (command == "Print")
                    {
                        listyIterator.Print();
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if (command == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (command == "PrintAll")
                    {
                        foreach (var item in listyIterator)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }
        }
    }
}
