using P08MilitaryElite.Contracts;
using P08MilitaryElite.Enumerations;
using P08MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString()
                + Environment.NewLine
                + $"Corps: {this.Corps}";
        }
    }
}
