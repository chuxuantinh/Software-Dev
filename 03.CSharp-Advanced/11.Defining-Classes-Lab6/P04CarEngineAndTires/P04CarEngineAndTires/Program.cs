using System;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 1),
                new Tire(1, 1),
                new Tire(1, 1),
                new Tire(1, 1)
            };

            var engine = new Engine(1, 1);

            var car = new Car("L", "U", 2010, 250, 9, engine, tires);
            
        }
    }
}
