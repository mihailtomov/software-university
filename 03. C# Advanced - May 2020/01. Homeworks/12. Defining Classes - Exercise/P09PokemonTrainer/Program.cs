using System;
using System.Collections.Generic;
using System.Linq;

namespace P09PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                  
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer();
                }

                trainers[trainerName].Pokemons.Add(pokemon);
            }

            string element;

            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var kvp in trainers)
                {
                    string trainerName = kvp.Key;
                    Trainer trainer = kvp.Value;
                    bool hasElement = false;

                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == element)
                        {
                            trainer.BadgeCount++;
                            hasElement = true;
                            break;
                        }
                    }

                    if (hasElement == false)
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            Pokemon pokemon = trainer.Pokemons[i];
                            pokemon.Health -= 10;

                            if (pokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(pokemon);
                                i--;
                            }
                        }
                    }
                }
            }

            trainers = trainers
                .OrderByDescending(kvp => kvp.Value.BadgeCount)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var kvp in trainers)
            {
                string trainerName = kvp.Key;
                int badges = kvp.Value.BadgeCount;
                int numberOfPokemon = kvp.Value.Pokemons.Count;

                Console.WriteLine($"{trainerName} {badges} {numberOfPokemon}");
            }
        }
    }
}
