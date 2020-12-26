using System;
using System.Collections.Generic;
using System.Linq;

namespace P05BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> tokens = Console.ReadLine().Split().Select(int.Parse).ToList();
            int specialNumber = tokens[0];
            int power = tokens[1];
            int distanceBetweenBombs = 2 * power;
            for (int i = 0; i < numbers.Count; i++)
            {
                distanceBetweenBombs++;
                if (numbers[i] == specialNumber && distanceBetweenBombs - power - 1 >= power)
                {

                    numbers.Remove(specialNumber);
                    i = i - 1;
                    if (power == 0)
                    {
                        continue;
                    }
                    for (int j = 0; j < power; j++)
                    {
                        if (i + 1 <= numbers.Count - 1)
                        {
                            numbers.RemoveAt(i + 1);
                        }
                    }
                    for (int j = 0; j < power; j++)
                    {
                        if (i >= 0)
                        {
                            numbers.RemoveAt(i);
                            i--;
                        }
                    }
                    distanceBetweenBombs = 0;//greshi
                }
                
            }
            Console.WriteLine(numbers.Sum());

        }
    }
}
