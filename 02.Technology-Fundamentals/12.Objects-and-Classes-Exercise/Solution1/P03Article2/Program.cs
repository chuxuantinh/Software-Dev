using System;
using System.Collections.Generic;
using System.Linq;

namespace P02Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article article = new Article(input[0], input[1], input[2]);

                articles.Add(article);
            }
            string criteria = Console.ReadLine();
                        
            if (criteria == "title")
            {
                List<Article> orderedArticles = articles.OrderBy(a => a.Title).ToList();
                foreach (Article article in orderedArticles)
                {
                    Console.WriteLine(article.ToString());
                }
            }
            if (criteria == "content")
            {
                List<Article> orderedArticles = articles.OrderBy(a => a.Content).ToList();
                foreach (Article article in orderedArticles)
                {
                    Console.WriteLine(article.ToString());
                }
            }
            if (criteria == "author")
            {
                List<Article> orderedArticles = articles.OrderBy(a => a.Author).ToList();
                foreach (Article article in orderedArticles)
                {
                    Console.WriteLine(article.ToString());
                }
            }

        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
