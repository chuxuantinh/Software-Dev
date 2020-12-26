using System;
using System.Collections.Generic;
using System.Linq;

namespace P03TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> nonnumbersList = Console.ReadLine().ToCharArray().ToList();
            List<int> numbersList = new List<int>();
            
            for (int i = 0; i < nonnumbersList.Count; i++)
            {
                
                if (Char.IsDigit(nonnumbersList[i]))
                {
                    
                    int num = int.Parse(nonnumbersList[i].ToString());
                    numbersList.Add(num);
                    nonnumbersList.Remove(nonnumbersList[i]);
                    i--;
                    
                }
            }
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else
                {
                   skipList.Add(numbersList[i]);
                }
            }
            string result = string.Empty;
            int total = 0;
            for (int i = 0; i < skipList.Count; i++)
            {
                int skipCount = skipList[i];
                int takeCoun = takeList[i];
                result += new string(nonnumbersList.Skip(total).Take(takeCoun).ToArray());
                total += skipCount + takeCoun;
            }
            Console.WriteLine(result);
        }
    }
}
