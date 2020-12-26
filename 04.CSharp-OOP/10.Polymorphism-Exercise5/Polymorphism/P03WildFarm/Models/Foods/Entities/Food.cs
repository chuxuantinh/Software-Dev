using P03WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03WildFarm.Models.Foods.Entities
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantuty = quantity;
        }

        public int Quantuty { get; private set; }
    }
}
