using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut, IAstronaut
    {
        private const double InitialOxygen = 70;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
            
        }

        public override void Breath()
        {
            this.Oxygen -=5;
        }
    }
}
