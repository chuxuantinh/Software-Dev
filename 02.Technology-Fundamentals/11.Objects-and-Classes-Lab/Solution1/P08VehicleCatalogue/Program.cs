using System;
using System.Collections.Generic;
using System.Linq;

namespace P08VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split("/");
                string command = tokens[0];
                if (command == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        HorsePower = int.Parse(tokens[3])

                    };
                    catalogue.CarsCatalogue.Add(car);
                }
                else if (command == "Truck")
                {
                    Truck truck = new Truck()
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        Weight = int.Parse(tokens[3])

                    };
                    catalogue.TrucksCatalogue.Add(truck);
                }
                input = Console.ReadLine();
            }
            List<Car> orderedCars = catalogue.CarsCatalogue.OrderBy(c => c.Brand).ToList();
            List<Truck> orderedTrucks = catalogue.TrucksCatalogue.OrderBy(t => t.Brand).ToList();
            if (orderedCars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
                
            }
            if (orderedTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    public class Catalogue
    {
        public Catalogue()
        {
            TrucksCatalogue = new List<Truck>();
            CarsCatalogue = new List<Car>();
        }
        public List<Truck> TrucksCatalogue { get; set; }
        public List<Car> CarsCatalogue { get; set; }
        
    }
}




