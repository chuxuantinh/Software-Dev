using System;
using System.Linq;

namespace _02.Guitar
{
    internal class Program
    {
        private static void Main()
        {
            var volumeChanges = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var startVolume = int.Parse(Console.ReadLine());
            var maxVolume = int.Parse(Console.ReadLine());

            var volumesMatrix = new bool[volumeChanges.Length + 1, maxVolume + 1];

            volumesMatrix[0, startVolume] = true;

            for (var i = 0; i < volumeChanges.Length; i++)
            {
                var changed = false;
                var changeVolume = volumeChanges[i];

                for (var j = 0; j <= maxVolume; j++)
                {
                    if (!volumesMatrix[i, j])
                    {
                        continue;
                    }

                    if (j + changeVolume <= maxVolume)
                    {
                        volumesMatrix[i + 1, j + changeVolume] = true;
                        changed = true;
                    }

                    if (j - changeVolume >= 0)
                    {
                        volumesMatrix[i + 1, j - changeVolume] = true;
                        changed = true;
                    }
                }

                if (!changed)
                {
                    break;
                }
            }

            var finalSongMaxVolume = -1;

            for (var i = maxVolume; i >= 0; i--)
            {
                if (!volumesMatrix[volumeChanges.Length, i])
                {
                    continue;
                }

                finalSongMaxVolume = i;
                break;
            }

            Console.WriteLine(finalSongMaxVolume);
        }
    }
}