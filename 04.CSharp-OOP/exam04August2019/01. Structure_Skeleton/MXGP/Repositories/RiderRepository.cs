using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public IReadOnlyCollection<IRider> Riders => this.riders;

        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.Riders;
        }

        public IRider GetByName(string name)
        {
            return this.Riders?.FirstOrDefault(r => r.Name == name);
        }

        public bool Remove(IRider model)
        {
            if (this.Riders?.FirstOrDefault(r => r == model) != null)
            {
                this.riders.Remove(model);
                return true;
            }

            return false;
        }
    }
}
