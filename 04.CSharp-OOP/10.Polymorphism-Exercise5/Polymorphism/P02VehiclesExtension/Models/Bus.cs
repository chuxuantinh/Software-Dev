using System;
using System.Collections.Generic;
using System.Text;

namespace P02VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double FuelConsumptionIncreaser => 1.4;

        protected override double RefuelMultiplier => 1;

        public void DriveEmpty(double distance)
        {
            if (distance * (this.FuelConsumption - this.FuelConsumptionIncreaser) <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * (this.FuelConsumption - this.FuelConsumptionIncreaser);
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}
