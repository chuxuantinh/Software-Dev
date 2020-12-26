using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainers
{
    public class Trainer
    {
        private const int DefaultValueNumberOfBadges = 0;
        public Trainer(string name)
        {
            Name = name;
            Badges = DefaultValueNumberOfBadges;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
