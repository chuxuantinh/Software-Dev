using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager mm;

        public Engine()
        {
            this.mm = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Quit")
                {
                    break;
                }

                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                try
                {
                    if (command == "HirePilot")
                    {
                        string name = inputArgs[1];
                        Console.WriteLine(this.mm.HirePilot(name));
                    }
                    else if (command == "PilotReport")
                    {
                        string name = inputArgs[1];
                        Console.WriteLine(this.mm.PilotReport(name));
                    }
                    else if (command == "ManufactureTank")
                    {
                        string name = inputArgs[1];
                        double attack = double.Parse(inputArgs[2]);
                        double defence = double.Parse(inputArgs[3]);
                        Console.WriteLine(this.mm.ManufactureTank(name, attack, defence));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        string name = inputArgs[1];
                        double attack = double.Parse(inputArgs[2]);
                        double defence = double.Parse(inputArgs[3]);
                        Console.WriteLine(this.mm.ManufactureFighter(name, attack, defence));
                    }
                    else if (command == "MachineReport")
                    {
                        string name = inputArgs[1];
                        Console.WriteLine(this.mm.MachineReport(name));
                    }
                    else if (command == "AggressiveMode")
                    {
                        string name = inputArgs[1];
                        Console.WriteLine(this.mm.ToggleFighterAggressiveMode(name));
                    }
                    else if (command == "DefenseMode")
                    {
                        string name = inputArgs[1];
                        Console.WriteLine(this.mm.ToggleTankDefenseMode(name));
                    }
                    else if (command == "Engage")
                    {
                        string pilotName = inputArgs[1];
                        string machineName = inputArgs[2];
                        Console.WriteLine(this.mm.EngageMachine(pilotName, machineName));
                    }
                    else if (command == "Attack")
                    {
                        string attackingMachineName = inputArgs[1];
                        string defendingMachineName = inputArgs[2];
                        Console.WriteLine(this.mm.AttackMachines(attackingMachineName, defendingMachineName));
                    }
                }
                catch (NullReferenceException nre)
                {
                    Console.WriteLine(nre.Message);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
            }
        }
    }
}
