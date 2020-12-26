using P02VehiclesExtension.Contracts;
using P02VehiclesExtension.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + this.FuelConsumptionIncreaser;
            }
        }

        public double TankCapacity { get; protected set; }

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
            if (liters <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAmountOfFuelException);
            }
            else if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.TooMuchFuelException, liters));
            }

            this.FuelQuantity += liters * this.RefuelMultiplier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
