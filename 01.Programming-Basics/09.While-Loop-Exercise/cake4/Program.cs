using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int cake = width * lenght;
            int pieces = 0;
            string input = "";
            int newPiece = 0;
            while (input != "STOP")
            {
                if (pieces > cake) break;
                input = Console.ReadLine();
                newPiece = int.Parse(input);
                pieces += newPiece;
            }
            if (pieces > cake)
            {
                Console.WriteLine($"No more cake left! You need {pieces - cake} pieces more.");
            }
            else if (pieces <= cake)
            {
                Console.WriteLine($"{cake - pieces} pieces are left.");
            }
        }
    }
}
