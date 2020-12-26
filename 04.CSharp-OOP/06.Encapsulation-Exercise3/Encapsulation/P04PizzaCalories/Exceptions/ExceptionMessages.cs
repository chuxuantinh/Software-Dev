using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories.Exceptions
{
    public static class ExceptionMessages
    {
        public static string InvalidTypeOfDough = "Invalid type of dough.";
        public static string InvalidWeightOfDough = "Dough weight should be in the range [1..200].";
        public static string InvalidTopping = "Cannot place {0} on top of your pizza.";
        public static string InvalidWeightOfTopping = "{0} weight should be in the range [1..50].";
        public static string InvalidPizzaName = "Pizza name should be between 1 and 15 symbols.";
        public static string InvalidNumberOfToppings = "Number of toppings should be in range [0..10].";
    }
}
