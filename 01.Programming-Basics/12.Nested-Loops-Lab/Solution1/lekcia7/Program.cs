using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z6
{
    class Program
    {
        static void Main(string[] args)
        {
            int batchCount = int.Parse(Console.ReadLine());
            //int currentBatchNumber = 1;
            //while (currentbatchnumber <= batchcount)
            //{

            //}
            for (int currentBatchNumber = 1; currentBatchNumber <= batchCount; currentBatchNumber++)
            {
                bool isFlourPresent = false;
                bool isEggsPresent = false;
                bool isSugarPresent = false;

                while (true)
                {
                    string productName = Console.ReadLine().ToLower();
                    if (productName == "sugar")
                    {
                        isSugarPresent = true;
                    }
                    else if (productName == "eggs")
                    {
                        isEggsPresent = true;
                    }
                    else if (productName == "flour")
                    {
                        isFlourPresent = true;
                    }
                    else if (productName == "bake!")
                    {
                        if (isEggsPresent && isFlourPresent && isSugarPresent)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        }
                    }
                }
                Console.WriteLine($"Baking batch number {currentBatchNumber}...");

            }
        }
    }
}
