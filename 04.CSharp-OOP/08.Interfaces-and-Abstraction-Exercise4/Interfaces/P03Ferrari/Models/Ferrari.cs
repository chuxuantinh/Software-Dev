using P03Ferrari.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03Ferrari.Models
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Gas => "Gas!";

        public string Break => "Brakes!";

        public string Model => "488-Spider";

        public string Driver { get; private set; }

        public override string ToString()
        {
            return $"{this.Model}/{this.Break}/{this.Gas}/{this.Driver}";
        }
    }
}
