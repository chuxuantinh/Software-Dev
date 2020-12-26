using System;
using System.Collections.Generic;
using System.Text;

namespace P02VehiclesExtension.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        void Drive(double distance);

        void Refuel(double liters);
    }
}
