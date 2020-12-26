using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace familyHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double electricity = 0.0;
            double totalElectricity = 0.0;
            double others = 0.0;
            double totalOthers = 0.0;
            for (int i = 0; i < months; i++)
            {
                electricity = double.Parse(Console.ReadLine());
                totalElectricity += electricity;
                others = (electricity + 20 + 15) * 1.2;
                totalOthers += others;
            }
            double totalWater = months * 20;
            double totalInternet = months * 15;
            double average = (totalElectricity + totalWater + totalInternet + totalOthers) / months;
            Console.WriteLine($"Electricity: {totalElectricity:f2} lv");
            Console.WriteLine($"Water: {totalWater:f2} lv");
            Console.WriteLine($"Internet: {totalInternet:f2} lv");
            Console.WriteLine($"Other: {totalOthers:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");
        }
    }
}
