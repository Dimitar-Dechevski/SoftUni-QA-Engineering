using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    internal class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name, int badges, List<Pokemon> pokemons)
        {
            Name = name;
            Badges = badges;
            Pokemons = pokemons;
        }

    }
}
