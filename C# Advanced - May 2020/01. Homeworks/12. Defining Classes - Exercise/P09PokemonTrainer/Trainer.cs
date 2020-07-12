using System.Collections.Generic;

namespace P09PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {
            this.Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int BadgeCount { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
