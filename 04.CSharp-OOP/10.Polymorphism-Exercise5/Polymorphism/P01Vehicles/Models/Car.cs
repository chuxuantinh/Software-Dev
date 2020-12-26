using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double FuelConsumptionIncreaser => 0.9;

        protected override double RefuelMultiplier => 1.0;
    }
}
