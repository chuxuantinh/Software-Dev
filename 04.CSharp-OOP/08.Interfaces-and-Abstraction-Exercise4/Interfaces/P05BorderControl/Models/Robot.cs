using P05BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05BorderControl.Models
{
    public class Robot : Inhabitant, IRobot
    {
        public Robot(string model, string id) : base(id)
        {
            this.Model = model;
        }

        public string Model { get; private set; }

       
    }
}
