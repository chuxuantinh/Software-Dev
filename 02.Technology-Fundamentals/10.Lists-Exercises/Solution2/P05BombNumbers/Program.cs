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
            int distanceBetweenBombs = power;
            for (int i = 0; i < numbers.Count; i++)
            {
                distanceBetweenBombs++;
                if (numbers[i] == specialNumber && distanceBetweenBombs > power)
                {
                    distanceBetweenBombs = 0;
                    int countSkipLeft = 0;
                    int countRemoveLeft = 0;
                    for (int j = 0; j < power; j++)
                    {
                        if (i - power + j < 0)
                        {
                            countSkipLeft++;
                            continue;
                        }
                        else
                        {
                            numbers.RemoveAt(i - power);
                            countRemoveLeft++;
                        }
                    }
                    int countRemoveRight = 0;
                    for (int j = 0; j < power; j++)
                    {
                        if (i + power - j - countRemoveLeft > numbers.Count - 1)
                        {
                           
                            continue;
                        }
                        else
                        {
                            numbers.RemoveAt(i + power - j - countRemoveLeft);
                            countRemoveRight++;
                            
                        }
                    }
                    numbers.Remove(specialNumber);
                    i = i - power - 1 + countSkipLeft;
                }
                else if (numbers[i] == specialNumber && distanceBetweenBombs <= power)
                {
                    distanceBetweenBombs = 0;
                    int countRemoveLeft = 0;
                    for (int k = 1; k <= power; k++)
                    {
                        if (k == distanceBetweenBombs)
                        {
                            break;
                        }
                        
                        numbers.RemoveAt(i - 1);
                        countRemoveLeft++;
                            
                    }
                    for (int j = 0; j < power; j++)
                    {
                        if (i + power - j - countRemoveLeft > numbers.Count - 1)
                        {

                            continue;
                        }
                        else
                        {
                            numbers.RemoveAt(i + power - j - countRemoveLeft);
                            

                        }
                    }
                    numbers.Remove(specialNumber);
                    i = i - countRemoveLeft;



                }
            }
            Console.WriteLine(numbers.Sum());

        }
    }
}
