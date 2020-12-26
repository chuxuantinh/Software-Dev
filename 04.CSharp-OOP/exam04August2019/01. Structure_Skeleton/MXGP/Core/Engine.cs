using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine()
                        .Split()
                        .ToArray();

                    if (input[0] == "CreateRider")
                    {
                        string riderName = input[1];
                        Console.WriteLine(this.championshipController.CreateRider(riderName));
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        string motorcycleType = input[1];
                        string model = input[2];
                        int horsePower = int.Parse(input[3]);
                        Console.WriteLine(this.championshipController.CreateMotorcycle(motorcycleType, model, horsePower));
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        string riderName = input[1];
                        string motorcycleName = input[2];
                        Console.WriteLine(this.championshipController.AddMotorcycleToRider(riderName, motorcycleName));
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        string raceName = input[1];
                        string riderName = input[2];
                        Console.WriteLine(this.championshipController.AddRiderToRace(raceName, riderName));
                    }
                    else if (input[0] == "CreateRace")
                    {
                        string raceName = input[1];
                        int laps = int.Parse(input[2]);
                        Console.WriteLine(this.championshipController.CreateRace(raceName, laps));
                    }
                    else if (input[0] == "StartRace")
                    {
                        string raceName = input[1];
                        Console.WriteLine(this.championshipController.StartRace(raceName));
                    }
                    else if (input[0] == "End")
                    {
                        this.championshipController.End();
                    }
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
