using P06BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P06BirthdayCelebrations.Models
{
    public class Pet : IPet
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birtdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birtdate { get; private set; }
    }
}
