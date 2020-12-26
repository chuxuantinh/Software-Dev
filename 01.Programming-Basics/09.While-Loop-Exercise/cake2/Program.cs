using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake2
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cake = width * length;
            int residue = 0;
            string command = "";

            while (cake >= 0)
            {
                command = Console.ReadLine();
                if (command == "STOP") break;
                int piece = int.Parse(command);
                residue = cake - piece;
                cake = residue;
            }
            if (residue <= 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(residue)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{residue} pieces are left.");
            }

        }

    }
}