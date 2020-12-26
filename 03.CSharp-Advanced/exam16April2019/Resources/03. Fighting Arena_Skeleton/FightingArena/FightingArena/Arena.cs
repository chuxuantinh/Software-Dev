using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            Name = name;
            gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count => gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator gladiatorToRemove = gladiators.FirstOrDefault(g => g.Name == name);
            gladiators.Remove(gladiatorToRemove);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return gladiators.OrderByDescending(g => g.GetStatPower()).First();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return gladiators.OrderByDescending(g => g.GetWeaponPower()).First();
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return gladiators.OrderByDescending(g => g.GetTotalPower()).First();
        }

        public override string ToString()
        {
            return $"[{Name}] - [{Count}] gladiators are participating.";
        }
    }
}
