using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashingMachine = double.Parse(Console.ReadLine());
            int priceToy = int.Parse(Console.ReadLine());
            double sum = 0;
            double totalMoney = 0;
            int brotherMoney = 0;
            int countToys = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    sum += 10;
                    totalMoney += sum;
                    brotherMoney++;
                }
                else
                {
                    countToys++;
                }
            }
            totalMoney += countToys * priceToy - brotherMoney;
            if (totalMoney >= priceWashingMachine)
            {
                Console.WriteLine($"Yes! {(totalMoney - priceWashingMachine):f2}");
            }
            else
            {
                Console.WriteLine($"No! {(priceWashingMachine - totalMoney):f2}");
            }
        }
    }
}
