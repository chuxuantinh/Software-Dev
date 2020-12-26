using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03ArrayBasedStack
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> stack = new ArrayStack<int>();
            stack.Push(1);
            stack.Push(2);

            Console.WriteLine(string.Join(" ", stack.ToArray()));
        }
    }
}
