using P06BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P06BirthdayCelebrations.Models
{
    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birtdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birtdate { get; private set; }

        
    }
}
