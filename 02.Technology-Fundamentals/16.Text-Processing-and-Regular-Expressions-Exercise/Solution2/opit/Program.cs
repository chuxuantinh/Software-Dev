using System;

namespace opit
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] winningSymbols = new string[] { "@", "#", "$", @"\^" };
            if (winningSymbols[3] == @"\^")
            {
                Console.WriteLine(winningSymbols[3]);
            }
            
        }
    }
}
