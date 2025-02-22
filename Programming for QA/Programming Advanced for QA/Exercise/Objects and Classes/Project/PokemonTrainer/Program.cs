using System.Text;

namespace PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> listOfTrainers = new List<Trainer>();

            while (!input.Equals("Tournament"))
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (listOfTrainers.Any(p => p.Name.Equals(trainerName)))
                {
                    Trainer existedTrainer = listOfTrainers.Find(p => p.Name.Equals(trainerName));
                    int index = listOfTrainers.IndexOf(existedTrainer);
                    listOfTrainers[index].Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, 0, new List<Pokemon>());
                    trainer.Pokemons.Add(pokemon);
                    listOfTrainers.Add(trainer);
                }

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (!command.Equals("End"))
            {
                string element = command;

                foreach (Trainer trainer in listOfTrainers)
                {
                    if (trainer.Pokemons.Count != 0)
                    {
                        if (trainer.Pokemons.Any(p => p.Element.Equals(element)))
                        {
                            trainer.Badges = trainer.Badges + 1;
                        }
                        else
                        {
                            trainer.Pokemons.ForEach(p => p.Health -= 10);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                listOfTrainers.ForEach(p => p.Pokemons = p.Pokemons.Where(p => p.Health > 0).ToList());
                command = Console.ReadLine();
            }

            listOfTrainers = listOfTrainers.OrderByDescending(p => p.Badges).ToList();

            foreach (Trainer trainer in listOfTrainers)
            {
                Console.Write($"{trainer.Name} ");
                Console.Write($"{trainer.Badges} ");
                Console.Write($"{trainer.Pokemons.Count}");
                Console.WriteLine();
            }

        }
    }
}

