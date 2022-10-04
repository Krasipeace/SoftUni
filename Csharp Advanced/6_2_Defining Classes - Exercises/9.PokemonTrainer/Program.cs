using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            GetPokemons(trainers);

            UsePokemons(trainers);

            PrintTrainers(trainers);
        }

        static void GetPokemons(List<Trainer> trainers)
        {
            string command = Console.ReadLine();
            while (command != "Tournament")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var trainer = trainers.SingleOrDefault(t => t.Name == tokens[0]);

                switch (trainer)
                {
                    case null:
                        trainer = new Trainer(tokens[0]);
                        trainer.Pokemons.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));
                        trainers.Add(trainer);
                        break;
                    default:
                        trainer.Pokemons.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));
                        break;
                }
                command = Console.ReadLine();
            }
        }

        static void UsePokemons(List<Trainer> trainers)
        {
            string element = Console.ReadLine();
            while (element != "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    var trainer = trainers[i];
                    trainer.CheckPokemon(element);
                }

                element = Console.ReadLine();
            }
        }

        static void PrintTrainers(List<Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
