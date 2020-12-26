using P06BirthdayCelebrations.Contracts;
using P06BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P06BirthdayCelebrations.Core
{
    public class Engine
    {
        private readonly List<IBirthable> inhabitants;

        public Engine()
        {
            this.inhabitants = new List<IBirthable>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                
                string[] commandArgs = command
                    .Split();

                string type = commandArgs[0];

                if (type == "Citizen")
                {
                    string name = commandArgs[1];
                    int age = int.Parse(commandArgs[2]);
                    string id = commandArgs[3];
                    string birthdate = commandArgs[4];

                    IBirthable inhabitant = new Citizen(name, age, id, birthdate);

                    this.inhabitants.Add(inhabitant);
                }
                else if (type == "Pet")
                {
                    string name = commandArgs[1];
                    string birthdate = commandArgs[2];

                    IBirthable inhabitant = new Pet(name, birthdate);

                    this.inhabitants.Add(inhabitant);
                }

                command = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var inhabitant in this.inhabitants)
            {
                if (inhabitant.Birtdate.EndsWith(year))
                {
                    Console.WriteLine(inhabitant.Birtdate);
                }
            }
        }
    }
}
