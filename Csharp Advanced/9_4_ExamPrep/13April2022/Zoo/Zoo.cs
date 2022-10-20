using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; set; }
        public int Count => Animals.Count;

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Animals.Count >= Capacity)
            {
                return "The zoo is full.";
            }
            Animals.Add(animal);

            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int removedAnimals = 0;
            for (int currAnimal = 0; currAnimal < Animals.Count; currAnimal++)
            {
                if (Animals[currAnimal].Species.Equals(species))
                {
                    removedAnimals++;
                    Animals.RemoveAt(currAnimal);
                    currAnimal--;
                }
            }

            return removedAnimals;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var onDiet = new List<Animal>();
            foreach (var item in Animals)
            {
                if (item.Diet == diet)
                {
                    onDiet.Add(item);
                }
            }

            return onDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            foreach (var item in Animals)
            {
                if (item.Weight == weight)
                {
                    return item;
                }
            }

            return null;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int counter = 0;
            foreach (var item in Animals)
            {
                if (item.Length >= minimumLength && item.Length <= maximumLength)
                {
                    counter++;
                }
            }

            return $"There are {counter} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
