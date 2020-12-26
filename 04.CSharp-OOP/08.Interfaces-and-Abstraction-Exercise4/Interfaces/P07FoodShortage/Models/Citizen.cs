using P07FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07FoodShortage.Models
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

        public int Food { get; private set; }

        public int BuyFood()
        {
            return this.Food += 10;
        }
    }
}
