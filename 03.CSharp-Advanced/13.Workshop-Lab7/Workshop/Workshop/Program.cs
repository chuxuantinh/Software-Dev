using System;
using System.Collections.Generic;
using System.Linq;

namespace Workshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new CustomList();

            list.ForEach(x =>
            {
                x = x + 1;
            });

            List<int> list2 = new List<int>();
            list2.Select(BiggerThan5);
        }

        public static bool BiggerThan5(int number)
        {
            bool result = false;
            if (number > 5)
            {
                result = true;
            }
            return result;
        }
    }
}
