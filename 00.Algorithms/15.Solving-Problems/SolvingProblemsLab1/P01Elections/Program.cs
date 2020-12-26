using System;
using System.Linq;
using System.Numerics;

namespace _01.Elections
{
    internal class Program
    {
        private static void Main()
        {
            var neededSeats = int.Parse(Console.ReadLine());
            var parties = int.Parse(Console.ReadLine());
            var votes = new int[parties];

            for (var i = 0; i < parties; i++)
            {
                votes[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(votes, (x, y) => x.CompareTo(y));

            var maxVotes = votes.Sum();

            var votesDp = new BigInteger[maxVotes + 1];
            votesDp[0] = BigInteger.One;

            var mostSeats = 0;

            foreach (var partyVotes in votes)
            {
                for (var j = mostSeats + partyVotes; j >= partyVotes; j--)
                {
                    if (votesDp[j - partyVotes].Equals(BigInteger.Zero))
                    {
                        continue;
                    }

                    if (mostSeats < j)
                    {
                        mostSeats = j;
                    }

                    votesDp[j] += votesDp[j - partyVotes];
                }
            }

            var combinations = BigInteger.Zero;

            for (var i = neededSeats; i <= maxVotes; i++)
            {
                combinations += votesDp[i];
            }

            Console.WriteLine(combinations);
        }
    }
}