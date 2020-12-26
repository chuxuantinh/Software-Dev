using P01Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] carArgs = Console.ReadLine()
                .Split()
                .ToArray();

            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckArgs = Console.ReadLine()
                .Split()
                .ToArray();

            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split()
                    .ToArray();

                string commandType = commandArgs[0];
                string vehicleType = commandArgs[1];

                if (commandType == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    if (vehicleType == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if (commandType == "Refuel")
                {
                    double liters = double.Parse(commandArgs[2]);

                    if (vehicleType == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
