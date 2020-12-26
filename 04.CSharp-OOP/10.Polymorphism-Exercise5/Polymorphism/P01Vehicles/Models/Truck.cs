using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double FuelConsumptionIncreaser => 1.6;

        protected override double RefuelMultiplier => 0.95;
    }
}
