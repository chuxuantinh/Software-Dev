using System;
using System.Collections.Generic;

namespace P06ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var entry = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> carPlates = new HashSet<string>();
            while (entry[0]?.ToLower() != "end")
            {
                switch (entry[0]?.ToLower())
                {
                    case "in":
                        carPlates.Add(entry[1]);
                        break;
                    case "out":
                        carPlates.Remove(entry[1]);
                        break;
                }
                entry = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (carPlates.Count > 0)
            {
                foreach (var carPlate in carPlates)
                {
                    Console.WriteLine(carPlate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
