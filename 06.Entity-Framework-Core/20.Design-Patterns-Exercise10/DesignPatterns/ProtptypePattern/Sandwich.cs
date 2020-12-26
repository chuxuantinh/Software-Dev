using System;
using System.Collections.Generic;
using System.Text;

namespace ProtptypePattern
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string vegies;

        public Sandwich(string bread, string meat, string cheese, string vegies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.vegies = vegies;
        }

        public override SandwichPrototype Clone()
        {
            string ingrediants = this.GetIngrediantsList();
            Console.WriteLine($"Cloning sandwich with ingrediants: {ingrediants}");

            return this.MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngrediantsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.vegies}";
        }
    }
}
