using P04PizzaCalories.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseModifier = 2.0;
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;

        private const int MaxWeightOfTopping = 50;
        private const int MinWeightOfTopping = 1;

        private string name;
        private int grams;

        public Topping(string name, int grams)
        {
            this.Name = name;
            this.Grams = grams;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value != "Meat" && value != "Meat".ToLower() && value != "Veggies" && value != "Veggies".ToLower() && value != "Cheese" && value != "Cheese".ToLower() && value != "Sauce" && value != "Sauce".ToLower())
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidTopping, value));
                }
                this.name = value;
            }
        }

        public int Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < MinWeightOfTopping || value > MaxWeightOfTopping)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidWeightOfTopping, this.Name));
                }
                this.grams = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                double totalCalories = 0;
                if (this.Name == "Meat" || this.Name == "Meat".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * MeatModifier;
                }
                else if (this.Name == "Veggies" || this.Name == "Veggies".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * VeggiesModifier;
                }
                else if (this.Name == "Cheese" || this.Name == "Cheese".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * CheeseModifier;
                }
                else if (this.Name == "Sauce" || this.Name == "Sauce".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * SauceModifier;
                }
                return totalCalories;
            }
        }
    }
}
