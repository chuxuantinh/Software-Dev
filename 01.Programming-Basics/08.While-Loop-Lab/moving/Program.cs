using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int space = width * lenght * height;
            string input;
            int currentSpace = 0;
            while (currentSpace < space)
            {
                input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                else
                {
                    int boxes = int.Parse(input);
                    currentSpace += boxes;
                }
            }
            if (currentSpace < space)
            {
                int freeSpace = space - currentSpace;
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
            else
            {
                int neededSpace = currentSpace - space;
                Console.WriteLine($"No more free space! You need {neededSpace} Cubic meters more.");
            }
        }
    }
}
