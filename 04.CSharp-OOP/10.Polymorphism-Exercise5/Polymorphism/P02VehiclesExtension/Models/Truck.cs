using System;
using System.Collections.Generic;
using System.Text;

namespace P02VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double FuelConsumptionIncreaser => 1.6;

        protected override double RefuelMultiplier => 0.95;
    }
}
