using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            heroes = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            heroes.Add(hero);
        }

        public int Count => heroes.Count;

        public void Remove(string name)
        {
            Hero targetHero = heroes.FirstOrDefault(x => x.Name == name);
            heroes.Remove(targetHero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = heroes.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = heroes.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = heroes.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
