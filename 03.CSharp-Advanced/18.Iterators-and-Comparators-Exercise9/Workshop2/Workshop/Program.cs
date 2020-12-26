using System;
using System.Collections.Generic;
using System.Linq;

namespace Workshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length > 1)
                    {
                        int[] numbers = new int[tokens.Length - 1];
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = int.Parse(tokens[i + 1]);
                        }
                        foreach (var item in numbers)
                        {
                            stack.Push(item);
                        }
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
