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
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int volume = width * length * height;
            string input = "";
            while (volume > 0)
            {
                
                input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                int boxes = int.Parse(input);
                volume -= boxes;
            }
            if (volume >= 0)
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {volume * -1} Cubic meters more.");
            }
        }
    }
}
