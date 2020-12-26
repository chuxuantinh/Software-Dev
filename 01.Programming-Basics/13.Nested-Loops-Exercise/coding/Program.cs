using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string numToString = num.ToString();
            for (int i = 0; i < numToString.Length; i++)
            {
                if (num % 10 == 0)
                {
                    Console.WriteLine("ZERO");
                    num = num / 10;
                }
                else
                {
                    string a = new string((char)((num % 10) + 33), num % 10);
                    Console.WriteLine(a);
                    num = num - num % 10;
                    num = num / 10;
                }
                
            }
        }
    }
}
