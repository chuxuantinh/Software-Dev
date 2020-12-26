using System;
using System.Collections.Generic;
using System.Linq;

namespace P07RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carsData = Console.ReadLine().Split();
                string model = carsData[0];
                int engineSpeed = int.Parse(carsData[1]);
                int enginePower = int.Parse(carsData[2]);
                Engine engine = new Engine(engineSpeed, enginePower);
                int cargoWeight = int.Parse(carsData[3]);
                string cargoType = carsData[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                double tire1Pressure = double.Parse(carsData[5]);
                int tire1Age = int.Parse(carsData[6]);
                double tire2Pressure = double.Parse(carsData[7]);
                int tire2Age = int.Parse(carsData[8]);
                double tire3Pressure = double.Parse(carsData[9]);
                int tire3Age = int.Parse(carsData[10]);
                double tire4Pressure = double.Parse(carsData[11]);
                int tire4Age = int.Parse(carsData[12]);
                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
                };
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string line = Console.ReadLine();
            if (line == "fragile")
            {
                cars = cars.Where(x => x.CarsCargo.CargoType == "fragile")
                    .Where(x => x.CarsTires[0].Pressure < 1 || x.CarsTires[1].Pressure < 1 || x.CarsTires[2].Pressure < 1 || x.CarsTires[3].Pressure < 1).ToList();
            }
            else if (line == "flamable")
            {
                cars = cars.Where(x => x.CarsCargo.CargoType == "flamable").Where(x => x.CarsEngine.EnginePower > 250).ToList();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }
}
