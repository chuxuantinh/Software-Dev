using P01Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelConsumption;


        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            private set
            {
                this.fuelConsumption = value + this.FuelConsumptionIncreaser;
            }
        }

        protected abstract double FuelConsumptionIncreaser { get; }

        protected abstract double RefuelMultiplier { get; }

        public void Drive(double distance)
        {
            if (distance * this.FuelConsumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public void Refuel(double liters)
        {
            this.FuelQuantity += liters * this.RefuelMultiplier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
