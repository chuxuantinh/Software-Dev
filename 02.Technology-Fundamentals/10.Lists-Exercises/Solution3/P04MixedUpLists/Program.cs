using System;
using System.Collections.Generic;
using System.Linq;

namespace P04MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbers2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> resultList = new List<int>();
            for (int i = 0; i < Math.Min(numbers1.Count, numbers2.Count); i++)
            {
                resultList.Add(numbers1[i]);
                resultList.Add(numbers2[numbers2.Count - 1 - i]);
            }
            List<int> range = new List<int>();
            if (numbers1.Count > numbers2.Count)
            {
                for (int i = numbers2.Count; i < numbers1.Count; i++)
                {
                    range.Add(numbers1[i]);
                }
            }
            else if (numbers1.Count < numbers2.Count)
            {
                for (int i = 0; i < 2; i++)
                {
                    range.Add(numbers2[i]);
                }
            }
            range.Sort();
            int startValue = range[0];
            int endValue = range[1];
            List<int> result = new List<int>();
            for (int i = 0; i < resultList.Count; i++)
            {
                if (startValue < resultList[i] && resultList[i] < endValue)
                {
                    result.Add(resultList[i]);
                }
            }
            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
