namespace BookShop
{
    using BookShop.Data.ViewModels;
    using BookShop.Models;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using AutoMapper.Collection;
    using AutoMapper.EquivalencyExpression;

    public class StartUp
    {
        public static void Main()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Book, BookDTO>()
            //        .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
            //});

            

            using (var db = new BookShopContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.AddCollectionMappers();
                    cfg.SetGeneratePropertyMaps
                        <GenerateEntityFrameworkCorePrimaryKeyPropertyMaps<BookShopContext>>();
                    cfg.CreateMap<Book, BookDTO>();
                    cfg.CreateMap<BookDTO, Book>()
                        .EqualityComparison((dto, o) => dto.BookId == o.BookId);
                    //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));
                    cfg.CreateMap<BookDTO, Book>();
                    //.ReverseMap()
                });

                //var books = db
                //    .Books
                //    .Select(b => new BookDTO() 
                //    {
                //        Title = b.Title,
                //        Price = b.Price,
                //        Author = $"{b.Author.FirstName} {b.Author.LastName}"
                //    })
                //    .ToList();

                //var bookDto = new BookDTO()
                //{
                //    Title = book.Title,
                //    Price = book.Price,
                //    Author =$"{book.Author.FirstName} {book.Author.LastName}" 
                //};

                //var book = db
                //    .Books
                //    .Include(b => b.Author)
                //    .First();

                //var bookDto = Mapper.Map<BookDTO>(book);

                //var bookDto = new BookDTO()
                //{
                //    Name = "Title",
                //    Price = 10m
                //};

                //var book = Mapper.Map<Book>(bookDto);

                //var books = db
                //    .Books
                //    .Where(b => b.EditionType.ToString() == "Gold")
                //    //.Select(b => new BookDTO
                //    //{ 
                //    //    Title = b.Title,
                //    //    Price = b.Price
                //    //})
                //    .ProjectTo<BookDTO>()
                //    .ToList();

                //var books = new List<Book>()
                //{
                //    new Book()
                //    {
                //        BookId = 1,
                //        Title = "Title1",
                //        Price = 30m
                //    },
                //    new Book()
                //    {
                //        BookId = 3,
                //        Title = "Title3",
                //        Price = 10m
                //    }
                //};

                //var booksDtos = new List<BookDTO>()
                //{
                //    new BookDTO()
                //    {
                //        BookId = 1,
                //        Title = "Title1"
                //    },
                //    new BookDTO()
                //    { 
                //        BookId = 2,
                //        Title = "Title2",
                //        Price = 20m
                //    }
                //};

                //Mapper.Map<List<BookDTO>, List<Book>>(booksDtos, books);

                var book = db
                    .Books
                    .First(b => b.BookId == 1);

                var bookDto = new BookDTO()
                {
                    Title = "Random Title",
                    Price = 15m
                };

                db.Books.Persist().InsertOrUpdate<BookDTO>(bookDto);//(mapper) for instance in Persist
                db.SubmitChanges();

                var changedBook = db
                    .Books
                    .First(b => b.BookId == 1);

                string result = JsonConvert.SerializeObject(books, Formatting.Indented);
                Console.WriteLine(result);

                
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //public static string GetBooksByCategory(BookShopContext context, string input)
        //{
        //    List<Book> books = new List<Book>();

        //    string[] categories = input
        //        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //        .Select(c => c.ToLower())
        //        .ToArray();

        //    foreach (var c in categories)
        //    {
        //        var booksToCategory = context
        //            .Books
        //            .Where(b => b.BookCategories.Select(bc => new { bc.Category.Name }).Any(ca => ca.Name.ToLower() == c))
        //            .ToList();

        //        books.AddRange(booksToCategory);
        //    }

        //    var orderedBooks = books
        //        .Select(b => b.Title)
        //        .OrderBy(b => b)
        //        .ToList();

        //    return String.Join(Environment.NewLine, orderedBooks);
        //}

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var books = context
                .Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            //var books = context
            //    .Books
            //    .Where(b => b.BookCategories.Select(bc => new { bc.Category.Name}).Any(bc => categories.Contains(bc.Name.ToLower())))
            //    .Select(b => b.Title)
            //    .OrderBy(b => b)
            //    .ToList();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksAndAuthors = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    Author = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToList();

            foreach (var b in booksAndAuthors)
            {
                sb.AppendLine($"{b.Title} ({b.Author})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.Name} - {a.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesAndMostRecentBooks = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    CategoryRecentBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        BookRelease = cb.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            foreach (var c in categoriesAndMostRecentBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");


                foreach (var b in c.CategoryRecentBooks)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.BookRelease})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.EditionType.ToString().ToLower() == "gold")
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksAndPrice = context
                .Books
                .Where(b => b.Price > 40m)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            foreach (var b in booksAndPrice)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.Name)
                .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine(a.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int result = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return result;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var profitsByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var bc in profitsByCategory)
            {
                sb.AppendLine($"{bc.Name} ${bc.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksForDelete = context.Books
               .Where(b => b.Copies < 4200)
               .ToList();

            context.RemoveRange(booksForDelete);
            context.SaveChanges();

            return booksForDelete.Count;
        }
    }
}
