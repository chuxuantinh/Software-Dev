
namespace P08BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<char> stackOfParentheses = new Stack<char>();
            char[] input = Console.ReadLine()
                .ToCharArray();
            char[] openParentheses = new char[] { '[', '{', '('};
            bool isValid = true;
            
            foreach (var item in input)
            {
                if (openParentheses.Contains(item))
                {
                    stackOfParentheses.Push(item);
                    continue;
                }
                if (stackOfParentheses.Count == 0)
                {
                    isValid = false;
                    break;
                }
                if (stackOfParentheses.Peek() == '(' && item == ')')
                {
                    stackOfParentheses.Pop();
                }
                else if (stackOfParentheses.Peek() == '[' && item == ']')
                {
                    stackOfParentheses.Pop();
                }
                else if (stackOfParentheses.Peek() == '{' && item == '}')
                {
                    stackOfParentheses.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
