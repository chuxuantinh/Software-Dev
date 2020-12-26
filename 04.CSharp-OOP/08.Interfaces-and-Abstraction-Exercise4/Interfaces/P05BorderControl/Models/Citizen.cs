using P05BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05BorderControl.Models
{
    public class Citizen : Inhabitant, ICitizen
    {
        public Citizen(string name, int age, string id) : base(id)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        
    }
}
