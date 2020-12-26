using System;

namespace P09PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());
            int freeBelts = countStudents / 6;
            double moneyEquipment = lightsabersPrice * Math.Ceiling(countStudents + 0.1 * countStudents) + robesPrice * countStudents + beltsPrice * (countStudents - freeBelts);
            if (moneyEquipment <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyEquipment:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(moneyEquipment - money):f2}lv more.");
            }
        }
    }
}
