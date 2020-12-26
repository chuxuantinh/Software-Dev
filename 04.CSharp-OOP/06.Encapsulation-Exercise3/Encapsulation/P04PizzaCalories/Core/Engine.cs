using P04PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string pizzaName = pizzaInfo[1];

                string[] doughInfo = Console.ReadLine().Split();
                string flourType = doughInfo[1].ToLower();
                string bakingTechnique = doughInfo[2].ToLower();
                int doughGrams = int.Parse(doughInfo[3]);

                Dough dough = new Dough(flourType, bakingTechnique, doughGrams);

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingInfo = command.Split();
                    string toppingName = toppingInfo[1];
                    int toppingGrams = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingName, toppingGrams);

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch(InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }
}
