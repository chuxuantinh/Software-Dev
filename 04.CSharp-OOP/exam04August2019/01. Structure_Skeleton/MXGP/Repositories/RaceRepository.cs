using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Races => this.races;

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.Races;
        }

        public IRace GetByName(string name)
        {
            return this.Races?.FirstOrDefault(r => r.Name == name);
        }

        public bool Remove(IRace model)
        {
            if (this.Races?.FirstOrDefault(r => r == model) != null)
            {
                this.races.Remove(model);
                return true;
            }

            return false;
        }
    }
}
