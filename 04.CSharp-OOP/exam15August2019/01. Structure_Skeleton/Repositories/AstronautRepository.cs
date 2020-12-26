using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private IList<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models.ToList();

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            if (this.models.Any(a => a.Name == name))
            {
                return this.models.First(a => a.Name == name);
            }

            return null;
        }

        public bool Remove(IAstronaut model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
