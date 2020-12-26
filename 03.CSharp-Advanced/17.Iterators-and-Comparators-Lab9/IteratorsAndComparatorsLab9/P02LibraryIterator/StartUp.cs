using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var books = new List<Book>()
            {
                new Book("Harry Potter", 2000, "J. K. Roling"),
                new Book("Dancing with dragons", 2012, "Martin"),
                new Book("I, Robot", 1978, "Azimov"),
                new Book("Programming Basics", 2012, "Svetlin Nakov", "Nikolay Nedialkov")
            };

            var library = new Library(books);

            foreach (var book in library)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
