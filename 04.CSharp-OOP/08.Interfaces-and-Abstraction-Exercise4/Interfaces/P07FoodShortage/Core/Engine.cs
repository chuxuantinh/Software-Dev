using P07FoodShortage.Contracts;
using P07FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07FoodShortage.Core
{
    public class Engine
    {
        private readonly List<IBuyer> buyers;

        public Engine()
        {
            this.buyers = new List<IBuyer>();
        }

        public void Run()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split();

                if (commandArgs.Length == 4)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string id = commandArgs[2];
                    string birthdate = commandArgs[3];

                    IBuyer buyer = new Citizen(name, age, id, birthdate);

                    this.buyers.Add(buyer);
                }
                else if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string group = commandArgs[2];

                    IBuyer buyer = new Rebel(name, age, group);

                    this.buyers.Add(buyer);
                }
            }

            int totalFood = 0;

            string command = Console.ReadLine();

            while (command != "End")
            {
                string name = command;

                IBuyer buyer = this.buyers.FirstOrDefault(b => b.Name == name);

                if (buyer != null)
                {
                    totalFood += - buyer.Food + buyer.BuyFood();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(totalFood);
        }
    }
}
