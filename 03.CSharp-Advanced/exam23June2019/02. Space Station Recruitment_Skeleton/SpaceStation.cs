using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            astronauts = new List<Astronaut>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => astronauts.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.Count < this.Capacity)
            {
                astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            bool exists = false;
            Astronaut targetAstronaut = astronauts.Where(x => x.Name == name).FirstOrDefault();
            if (targetAstronaut != null)
            {
                astronauts.Remove(targetAstronaut);
                exists = true;
            }
            return exists;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldestAstronaut = astronauts.OrderByDescending(a => a.Age).FirstOrDefault();
            return oldestAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = astronauts.Where(a => a.Name == name).FirstOrDefault();
            return astronaut;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {Name}:");
            foreach (var astronaut in astronauts)
            {
                sb.AppendLine(astronaut.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
