using P02VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02VehiclesExtension.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Car car = null;
            Truck truck = null;
            Bus bus = null;

            while (commandArgs.Length != 1)
            {
                string vehicleType = commandArgs[0];

                if (vehicleType == "Car")
                {
                    double carFuelQuantity = double.Parse(commandArgs[1]);
                    double carFuelConsumption = double.Parse(commandArgs[2]);
                    double carTankCapacity = double.Parse(commandArgs[3]);

                    car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
                }
                else if (vehicleType == "Truck")
                {
                    double truckFuelQuantity = double.Parse(commandArgs[1]);
                    double truckFuelConsumption = double.Parse(commandArgs[2]);
                    double truckTankCapacity = double.Parse(commandArgs[3]);

                    truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
                }
                else if (vehicleType == "Bus")
                {
                    double busFuelQuantity = double.Parse(commandArgs[1]);
                    double busFuelConsumption = double.Parse(commandArgs[2]);
                    double busTankCapacity = double.Parse(commandArgs[3]);

                    bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);
                }

                commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }
                
            int count = int.Parse(commandArgs[0]);

            for (int i = 0; i < count; i++)
            {
                string[] commandArgs2 = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandType = commandArgs2[0];
                string vehicleType1 = commandArgs2[1];

                if (commandType == "Drive")
                {
                    double distance = double.Parse(commandArgs2[2]);

                    if (vehicleType1 == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (vehicleType1 == "Truck")
                    {
                        truck.Drive(distance);
                    }
                    else if (vehicleType1 == "Bus")
                    {
                        bus.Drive(distance);
                    }
                }
                else if (commandType == "Refuel")
                {
                    double liters = double.Parse(commandArgs2[2]);

                    if (vehicleType1 == "Car")
                    {
                        try
                        {
                            car.Refuel(liters);
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                    }
                    else if (vehicleType1 == "Truck")
                    {
                        try
                        {
                            truck.Refuel(liters);
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                    }
                    else if (vehicleType1 == "Bus")
                    {
                        try
                        {
                            bus.Refuel(liters);
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                    }
                }
                else if (commandType == "DriveEmpty")
                {
                    double distance = double.Parse(commandArgs2[2]);
                    bus.DriveEmpty(distance);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
