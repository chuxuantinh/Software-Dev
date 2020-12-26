using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchedBook = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());
            int counter = 1;
            string input;
            while (counter <= capacity)
            {
                input = Console.ReadLine();
                if (searchedBook == input)
                {
                    Console.WriteLine($"You checked {counter - 1} books and found it.");
                    break;
                }      
                counter++;
            }
            if (counter - 1 == capacity)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {capacity} books.");
            }
        }
    }
}
