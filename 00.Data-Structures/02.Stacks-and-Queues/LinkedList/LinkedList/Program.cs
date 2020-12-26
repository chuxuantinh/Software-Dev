using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node<int> firstNode = new Node<int>(5);
            Node<int> secondNode = new Node<int>(10);
            Node<int> thirdNode = new Node<int>(15);

            firstNode.Next = secondNode;
            secondNode.Next = thirdNode;

            Node<int> current = firstNode;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
}
