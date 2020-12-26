using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }
        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            return GetWeaponPower() + GetStatPower();
        }

        public int GetWeaponPower()
        {
            return Weapon.Size + Weapon.Solidity + Weapon.Sharpness;
        }

        public int GetStatPower()
        {
            return Stat.Strength + Stat.Flexibility + Stat.Agility + Stat.Skills + Stat.Intelligence;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"[{Name}] - [{GetTotalPower()}]");
            result.AppendLine($"  Weapon Power: [{GetWeaponPower()}]");
            result.AppendLine($"  Stat Power: [{GetStatPower()}]");
            return result.ToString().TrimEnd();
        }
    }
}
