using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int numberRows = int.Parse(Console.ReadLine());
            int numberSeats = int.Parse(Console.ReadLine());
            int counter = 0;
            for (char i = 'A'; i <= sector; i++)
            {
                for (int j = 1; j <= numberRows; j++)
                {
                    if (j % 2 == 0)
                    {
                        for (char k = 'a'; k < 'a' + numberSeats + 2; k++)
                        {
                            Console.WriteLine($"{i}{j}{k}");
                            counter++;
                        }
                    }
                    else
                    {
                        for (char k = 'a'; k < 'a' + numberSeats; k++)
                        {
                            Console.WriteLine($"{i}{j}{k}");
                            counter++;
                        }
                    }
                }
                numberRows++;
            }
            Console.WriteLine(counter);
        }
    }
}
