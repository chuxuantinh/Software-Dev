using P07FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07FoodShortage.Models
{
    public class Rebel : IRebel
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            return this.Food += 5;
        }
    }
}
