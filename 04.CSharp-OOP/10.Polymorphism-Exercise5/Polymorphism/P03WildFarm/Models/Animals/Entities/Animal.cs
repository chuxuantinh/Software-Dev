using P03WildFarm.Exceptions;
using P03WildFarm.Models.Animals.Contracts;
using P03WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03WildFarm.Models.Animals.Entities
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract List<Type> PrefferedFoodTypes { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string AskFood();

        public void Feed(IFood food)
        {
            if (!this.PrefferedFoodTypes.Contains(food.GetType()))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFoodTypeException, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantuty * this.WeightMultiplier;

            this.FoodEaten += food.Quantuty;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
