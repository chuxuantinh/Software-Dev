using P05BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05BorderControl.Models
{
    public abstract class Inhabitant : IInhabitant
    {
        public Inhabitant(string id)
        {
            this.Id = id;
        }
        public string Id { get; private set; }

        
    }
}
