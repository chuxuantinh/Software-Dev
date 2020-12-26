using System;

namespace P01
{
    class Program
    {
        static Random rnd = new Random();
        static void Swap(int index1, int index2, string[] cards)
        {
            string oldCards = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = oldCards;
        }
        static void PrintCards(string[] cards)
        {
            Console.WriteLine(string.Join(", ", cards));
        }
        static void Main(string[] args)
        {
            string[] cards = { "AS", "10H", "2C", "KD" };
            PrintCards(cards);
            for (int i = 0; i < cards.Length; i++)
            {
                SingleRandomSwap(i, cards);
            }
            PrintCards(cards);
        }

        private static void SingleRandomSwap(int i, string[] cards)
        {
            int randPos = rnd.Next(0, cards.Length);
            Swap(i, randPos, cards);
        }
    }
}
