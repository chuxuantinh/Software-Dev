using System;

namespace P01AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int msgNumber = int.Parse(Console.ReadLine());
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] towns = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random number = new Random();
            for (int i = 0; i < msgNumber; i++)
            {
                int phrasesIndex = number.Next(0, phrases.Length);
                int eventIndex = number.Next(0, phrases.Length);
                int authorIndex = number.Next(0, phrases.Length);
                int townIndex = number.Next(0, phrases.Length);
                Console.WriteLine($"{phrases[phrasesIndex]} {events[eventIndex]} {authors[authorIndex]} – {towns[townIndex]}");
            }
        }
    }
}
