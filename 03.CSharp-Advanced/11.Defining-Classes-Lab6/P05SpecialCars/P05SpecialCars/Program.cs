using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private int horsePower;
        private double tirePressureSum;
        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value;
            }
        }
        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                this.horsePower = value;
            }
        }
        public double TirePressureSum
        {
            get
            {
                return this.tirePressureSum;
            }
            set
            {
                this.tirePressureSum = value;
            }
        }
        public void Drive(double distance)
        {
            bool canContinue = this.FuelQuantity - (distance * this.FuelConsumption / 100.0) >= 0;
            if (canContinue)
            {
                this.FuelQuantity -= distance * this.FuelConsumption / 100.0;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");
            return sb.ToString();
        }


        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, int horsePower, double tirePressureSum)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.HorsePower = horsePower;
            this.TirePressureSum = tirePressureSum;
        }

    }
    public class Tire
    {
        private int year;
        private double pressure;
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }

    }
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }
        public double CubicCapacity
        {
            get { return this.cubicCapacity; }
            set { this.cubicCapacity = value; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<double> tires = new List<double>();
            string command = Console.ReadLine();
            while (command != "No more tires")
            {
                string[] tokens = command.Split();
                double tirePressureSum = double.Parse(tokens[1]) + double.Parse(tokens[3]) + double.Parse(tokens[5]) + double.Parse(tokens[7]);
                tires.Add(tirePressureSum);
                command = Console.ReadLine();
            }
            List<int> engines = new List<int>();
            string input = Console.ReadLine();
            while (input != "Engines done")
            {
                string[] tokens = input.Split();
                int horsePower = int.Parse(tokens[0]);
                engines.Add(horsePower);
                input = Console.ReadLine();
            }
            List<Car> cars = new List<Car>();
            string line = Console.ReadLine();
            while (line != "Show special")
            {
                string[] tokens = line.Split();
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
                line = Console.ReadLine();
            }
            cars = cars.Where(x => x.Year >= 2017).Where(x => x.HorsePower > 330).Where(x => x.TirePressureSum > 9).Where(x => x.TirePressureSum < 10).ToList();
            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
