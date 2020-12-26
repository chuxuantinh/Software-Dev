using System;
using System.Collections.Generic;
using System.Text;

namespace LaptopShop
{
    public class Laptop
    {
        private string make;
        public Laptop(string make, string model, double displaySize, decimal price, int ram, int? ssd = null)
        {
            Make = make;
            Model = model;
            DisplaySize = displaySize;
            Price = price;
            Ram = ram;
            Ssd = ssd;
        }
        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.make = value;
            }
        }
                

        public string Model { get; private set; }

        public double DisplaySize { get; private set; }

        public decimal Price { get; private set; }

        public int Ram { get; private set; }

        public int? Ssd { get; private set; }

        public string FullInfo()
        {
            return $@"Make: {Make}
                      Model: {Model}
                      Price: {Price:f2}";
        }
    }
}
