﻿using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>(/*compareElements*/);

            foreach (var cookie in cookies)
            {
                priorityQueue.Add(cookie);
            }

            int currentMinSweetness = priorityQueue.GetFirst();
            int steps = 0;

            while (currentMinSweetness < k && priorityQueue.Count > 1)
            {
                int leastSweetCookie = priorityQueue.RemoveFirst();
                int secondLeastSweetCookie = priorityQueue.RemoveFirst();

                int combined = leastSweetCookie + 2 * secondLeastSweetCookie;

                priorityQueue.Add(combined);

                currentMinSweetness = priorityQueue.GetFirst();

                steps++;
            }

            return currentMinSweetness < k ? -1 : steps;

            int compareElements(int first, int second)
            {
                return second - first;
            }
        }
    }
}
