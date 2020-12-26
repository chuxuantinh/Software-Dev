using P04PizzaCalories.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04PizzaCalories.Models
{
    public class Pizza
    {
        private const int MinPizzaNameLenght = 1;
        private const int MaxPizzaNameLenght = 15;
        private const int MaxNumberOfToppings = 10;

        private string name;
        private List<Topping> toppings;

        public Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough) : this()
        {
            this.Name = name;
            this.Dough = dough;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinPizzaNameLenght || value.Length > MaxPizzaNameLenght)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaName);
                }
                this.name = value;
            }
        }

        public int NumberOfToppings
        {
            get
            {
                return this.toppings.Count;
            }
        }

        public Dough Dough { get; private set; }

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings < MaxNumberOfToppings)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidNumberOfToppings);
            }
        }

        public double TotalCalories
        {
            get
            {
                if (this.toppings.Count == 0)
                {
                    return this.Dough.TotalCalories;
                }
                return this.Dough.TotalCalories + this.toppings.Sum(t => t.TotalCalories);
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
