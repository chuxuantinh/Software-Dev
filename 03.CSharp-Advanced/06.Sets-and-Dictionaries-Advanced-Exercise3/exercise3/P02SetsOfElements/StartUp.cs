namespace P02SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firstSetSize = size[0];
            int secondSetSize = size[1];
            for (int i = 0; i < firstSetSize; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                firstSet.Add(currentNumber);
            }
            for (int i = 0; i < secondSetSize; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                secondSet.Add(currentNumber);
            }
            foreach (var currentItem in firstSet)
            {
                if (secondSet.Contains(currentItem))
                {
                    Console.Write(currentItem + " ");
                }
            }
        }
    }
}
