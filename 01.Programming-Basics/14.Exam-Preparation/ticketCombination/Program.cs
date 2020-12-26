using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int combinationNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int symbol1 = 'B'; symbol1 <= 'L'; symbol1 += 2)
            {
                for (int symbol2 = 'f'; symbol2 >= 'a'; symbol2--)
                {
                    for (int symbol3 = 'A'; symbol3 <= 'C'; symbol3++)
                    {
                        for (int symbol4 = 1; symbol4 <= 10; symbol4++)
                        {
                            for (int symbol5 = 10; symbol5 >= 1; symbol5--)
                            {
                                counter++;
                                if (combinationNumber == counter)
                                {
                                    int price = symbol1 + symbol2 + symbol3 + symbol4 + symbol5;
                                    string ticket = "" + (char)symbol1 + (char)symbol2 + (char)symbol3 + symbol4 + symbol5;
                                    Console.WriteLine($"Ticket combination: {ticket}");
                                    Console.WriteLine($"Prize: {price} lv.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
