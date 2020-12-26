using System;
using System.Collections.Generic;
using System.Text;

namespace BooksAfter
{
    public class Library
    {
        private IEnumerable<Book> books;

        public Library(IEnumerable<Book> books)
        {
            this.books = books;
        }

        public int FindBook(string title)
        {
            return 42;
        }
    }
}
