using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository ar;
        private PlanetRepository pr;
        private int numberOfExploredPlanets = 0;

        public Controller()
        {
            this.ar = new AstronautRepository();
            this.pr = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            this.ar.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.pr.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.pr.FindByName(planetName);
            List<IAstronaut> astronauts = this.ar.Models.Where(a => a.Oxygen > 60).ToList();
            int initialAstronautsCount = astronauts.Count;
            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }
            IMission mission = new Mission();
            mission.Explore(planet, astronauts);
            numberOfExploredPlanets++;
            return $"Planet: {planetName} was explored! Exploration finished with {initialAstronautsCount - astronauts.Count} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{numberOfExploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in this.ar.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (this.ar.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            var astronaut = this.ar.FindByName(astronautName);
            this.ar.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
