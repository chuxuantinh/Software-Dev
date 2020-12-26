using System;
using System.Collections.Generic;
using System.Linq;

namespace P05DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            List<int> drums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> initialDrums = new List<int>();
            for (int i = 0; i < drums.Count; i++)
            {
                initialDrums.Add(drums[i]);
            }
            string command = Console.ReadLine();
            
            while (command != "Hit it again, Gabsy!")
            {
                
                int power = int.Parse(command);
                
                for (int i = 0; i < drums.Count; i++)
                {
                    
                    drums[i] -= power;
                    
                    if (drums[i] <= 0 && initialDrums[i] * 3 <= money)
                    {
                        drums[i] = initialDrums[i];
                        money -= initialDrums[i] * 3;
                        
                    }
                    else if (drums[i] <= 0 && initialDrums[i] * 3 > money)
                    {
                        drums.Remove(drums[i]);
                        initialDrums.RemoveAt(i);
                        i--;
                    }

                }
                
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", drums));
            Console.WriteLine($"Gabsy has {money:f2}lv.");
        }
    }
}
