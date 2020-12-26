using P04PizzaCalories.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseModifier = 2.0;
        private const double WhiteModifier = 1.5;
        private const double WholegrainModifier = 1.0;
        private const double CrispyModifier = 0.9;
        private const double ChewyModifier = 1.1;
        private const double HomemadeModifier = 1.0;

        private const int MaxWeightOfDough = 200;
        private const int MinWeightOfDough = 1;

        private string flourType;
        private string bakingTechnique;
        private int grams;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value != "White".ToLower() && value != "Wholegrain".ToLower())
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value != "Crispy".ToLower() && value != "Chewy".ToLower() && value != "Homemade".ToLower())
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }
                this.bakingTechnique = value;
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
                if (value < MinWeightOfDough || value > MaxWeightOfDough)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidWeightOfDough);
                }
                this.grams = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                double totalCalories = 0;
                if (this.FlourType == "White".ToLower() && this.BakingTechnique == "Crispy".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * WhiteModifier * CrispyModifier;
                }
                else if (this.FlourType == "White".ToLower() && this.BakingTechnique == "Chewy".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * WhiteModifier * ChewyModifier;
                }
                else if (this.FlourType == "White".ToLower() && this.BakingTechnique == "Homemade".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * WhiteModifier * HomemadeModifier;
                }
                else if (this.FlourType == "Wholegrain".ToLower() && this.BakingTechnique == "Crispy".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * WholegrainModifier * CrispyModifier;
                }
                else if (this.FlourType == "Wholegrain".ToLower() && this.BakingTechnique == "Chewy".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * WholegrainModifier * ChewyModifier;
                }
                else if (this.FlourType == "Wholegrain".ToLower() && this.BakingTechnique == "Homemade".ToLower())
                {
                    totalCalories = this.Grams * BaseModifier * WholegrainModifier * HomemadeModifier;
                }
                return totalCalories;
            }
        }
    }
}
