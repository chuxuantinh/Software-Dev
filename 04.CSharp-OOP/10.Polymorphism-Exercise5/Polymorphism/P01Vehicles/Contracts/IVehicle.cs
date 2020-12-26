using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        void Drive(double distance);

        void Refuel(double liters);
    }
}
