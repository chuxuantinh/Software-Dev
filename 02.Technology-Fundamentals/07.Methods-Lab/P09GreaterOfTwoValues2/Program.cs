using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.GreaterOfTwoValues
{
    class Program
    {
        static int GetMax(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }

            else
            {
                return b;
            }
        }

        static char GetMax(char a, char b)
        {
            if ((int)(a) >= (int)(b))
            {
                return a;
            }

            else
            {
                return b;
            }
        }

        static string GetMax(string a, string b)
        {
            if (a.CompareTo(b) >= 0)
            {
                return a;
            }

            else
            {
                return b;
            }
        }

        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));
            }

            else if (type == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                Console.WriteLine(GetMax(a, b));
            }


            else if (type == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));
            }

        }
    }
}