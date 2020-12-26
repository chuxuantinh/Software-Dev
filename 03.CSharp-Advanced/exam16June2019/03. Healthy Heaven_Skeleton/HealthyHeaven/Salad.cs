using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> vegetables;
        public Salad(string name)
        {
            Name = name;
            vegetables = new List<Vegetable>();
        }
        
        public string Name { get; set; }

        public int GetTotalCalories()
        {
            int totalCalories = 0;
            foreach (var vegetable in vegetables)
            {
                totalCalories += vegetable.Calories;
            }
            return totalCalories;
        }

        public void Add(Vegetable product)
        {
            vegetables.Add(product);
        }

        public int GetProductCount()
        {
            int productCount = vegetables.Count;
            return productCount;
        }

        public override string ToString()
        {
            string sb = string.Empty;
            sb += $"* Salad {Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:";
            foreach (var vegetable in vegetables)
            {
                sb += Environment.NewLine + vegetable.ToString();
            }
            sb.TrimEnd();
            return sb;
        }
    }
}
