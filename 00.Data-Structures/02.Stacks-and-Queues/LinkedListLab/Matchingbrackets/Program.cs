﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matchingbrackets
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string expression = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = stack.Pop();
                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
