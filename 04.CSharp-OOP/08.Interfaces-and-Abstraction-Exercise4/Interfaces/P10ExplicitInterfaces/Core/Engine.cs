using P10ExplicitInterfaces.Contracts;
using P10ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P10ExplicitInterfaces.Core
{
    public class Engine
    {
        public Engine()
        {
            
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command
                    .Split();

                string name = commandArgs[0];
                string country = commandArgs[1];
                int age = int.Parse(commandArgs[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                Console.WriteLine(person.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());

                command = Console.ReadLine();
            }
        }
    }
}
