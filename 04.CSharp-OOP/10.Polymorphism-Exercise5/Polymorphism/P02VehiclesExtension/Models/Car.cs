using System;
using System.Collections.Generic;
using System.Text;

namespace P02VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double FuelConsumptionIncreaser => 0.9;

        protected override double RefuelMultiplier => 1.0;
    }
}
