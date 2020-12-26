using P05BorderControl.Contracts;
using P05BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05BorderControl.Core
{
    public class Engine
    {
        private readonly List<IInhabitant> inhabitants;

        public Engine()
        {
            this.inhabitants = new List<IInhabitant>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                
                string[] commandArgs = command
                    .Split();

                if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string id = commandArgs[2];

                    IInhabitant inhabitant = new Citizen(name, age, id);

                    this.inhabitants.Add(inhabitant);
                }
                else if (commandArgs.Length == 2)
                {
                    string model = commandArgs[0];
                    string id = commandArgs[1];

                    IInhabitant inhabitant = new Robot(model, id);

                    this.inhabitants.Add(inhabitant);
                }

                command = Console.ReadLine();
            }

            string number = Console.ReadLine();

            foreach (var inhabitant in this.inhabitants)
            {
                if (inhabitant.Id.EndsWith(number))
                {
                    Console.WriteLine(inhabitant.Id);
                }
            }
        }
    }
}
