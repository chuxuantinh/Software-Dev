using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private IList<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.ToList();

        public void Add(IGun model)
        {
            if (this.models.Contains(model))
            {
                return;
            }
            this.models.Add(model);
        }

        public IGun Find(string name)
        {
            return this.models.First(m => m.Name == name);
        }

        public bool Remove(IGun model)
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
