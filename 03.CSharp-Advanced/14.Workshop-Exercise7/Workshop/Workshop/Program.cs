using System;

namespace Workshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.AddFirst(1);
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddFirst(3);
            doublyLinkedList.Print(Console.WriteLine);
        }
    }
}
