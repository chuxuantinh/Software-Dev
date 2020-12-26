using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P03treasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "find")
            {
                StringBuilder sb = new StringBuilder(command);
                int j = 0;
                for (int i = 0; i < sb.Length; i++)
                {
                    if (j >= key.Length)
                    {
                        j = 0;
                    }
                    sb[i] -= (char)key[j];
                    j++;
                }
                Regex typePattern = new Regex(@"&(?<type>.+)&");
                Regex coordinatesPattern = new Regex(@"<(?<coordinates>.+)>");
                if (typePattern.IsMatch(sb.ToString()) && coordinatesPattern.IsMatch(sb.ToString()))
                {
                    string typeTreasure = typePattern.Match(sb.ToString()).Groups["type"].Value;
                    string coordinatesTreasure = coordinatesPattern.Match(sb.ToString()).Groups["coordinates"].Value;
                    Console.WriteLine($"Found {typeTreasure} at {coordinatesTreasure}");
                }
                command = Console.ReadLine();
            }
        }
    }
}
