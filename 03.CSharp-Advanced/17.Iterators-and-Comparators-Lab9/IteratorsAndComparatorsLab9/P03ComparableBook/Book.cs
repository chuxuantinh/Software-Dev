using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = new List<string>();
            Authors = authors.ToList();
            //Authors = new List<string>(authors);
            //Authors = authors.ToList();
            //Authors.AddRange(authors);
        }
        public string Title { get; private set; }

        public int Year { get; private set; }

        public List<string> Authors { get; private set; }

        public int CompareTo(Book other)
        {
            if (this.Year != other.Year)
            {
                return this.Year - other.Year;
            }

            if (this.Title != other.Title)
            {
                return this.Title.CompareTo(other.Title);
            }

            return 0;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
