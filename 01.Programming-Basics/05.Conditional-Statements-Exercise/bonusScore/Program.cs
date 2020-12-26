using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());
            double bonusScore1 = 0;
            
            if (score <= 100)
            {
                bonusScore1 += 5;
            }
            else if (score > 100 && score <= 1000)
            {
                bonusScore1 = score * 0.20;
            }
            else if (score > 1000)
            {
                bonusScore1 = score * 0.10;
            }
            if (score % 2 == 0)
            {
                bonusScore1 += 1;
            }
            else if (score % 10 == 5)
            {
                bonusScore1 += 2;
            }
            Console.WriteLine(bonusScore1);
            Console.WriteLine(score + bonusScore1);
        }
    }
}
