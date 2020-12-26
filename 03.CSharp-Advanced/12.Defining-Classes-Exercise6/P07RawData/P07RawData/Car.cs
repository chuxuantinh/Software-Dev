using System;
using System.Collections.Generic;
using System.Text;

namespace P07RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            CarsEngine = engine;
            CarsCargo = cargo;
            CarsTires = tires;

        }
        public string Model { get; set; }

        public Engine CarsEngine { get; set; }

        public Cargo CarsCargo { get; set; }

        public Tire[] CarsTires { get; set; }
    }

    
}
