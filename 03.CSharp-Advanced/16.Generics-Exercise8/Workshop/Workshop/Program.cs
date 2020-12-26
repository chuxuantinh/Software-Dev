using System;

namespace Workshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();
            
            doublyLinkedList.Print(Console.WriteLine);
        }
    }
}
