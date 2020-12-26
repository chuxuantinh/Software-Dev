using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nameWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxName = int.MinValue;
            string winner = "";
            while (input != "STOP")
            {
                int currentSum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    currentSum += input[i];
                }
                if (currentSum > maxName)
                {
                    maxName = currentSum;
                    winner = $"Winner is {input} - {maxName}!";
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(winner);
        }
    }
}
