using System;
using System.Collections.Generic;
using System.Text;

namespace P08CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = 0;
            Efficiency = "n/a";
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"    Power: {Power}");
            if (Displacement == 0)
            {
                sb.AppendLine("    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {Displacement}");
            }
            sb.Append($"    Efficiency: {Efficiency}");
            return sb.ToString();
        }
    }
}
