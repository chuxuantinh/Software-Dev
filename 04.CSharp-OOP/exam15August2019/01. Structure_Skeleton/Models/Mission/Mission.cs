using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (planet.Items.Count > 0)
            {
                var astronaut = astronauts.First();
                    while (astronaut.CanBreath)
                    {
                        var item = planet.Items.First();
                        planet.Items.Remove(item);
                        astronaut.Bag.Items.Add(item);
                        astronaut.Breath();
                        if (planet.Items.Count == 0)
                        {
                            break;
                        }
                    }
                    if (!astronaut.CanBreath)
                    {
                        astronauts.Remove(astronaut);
                    }
                    if (planet.Items.Count == 0)
                    {
                        break;
                    }
                
            }
        }
    }
}
