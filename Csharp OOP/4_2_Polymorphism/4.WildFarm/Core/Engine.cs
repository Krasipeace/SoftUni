namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;
        private readonly ICollection<IAnimal> animals;
        private Engine()
        {
            animals = new HashSet<IAnimal>();
        }
        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;

            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                GetInput(command);
            }

            PrintResults();
        }

        private IAnimal CreateAnimal(string command)
        {
            string[] animalData = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IAnimal currAnimal = animalFactory.CreateAnimal(animalData);

            return currAnimal;
        }
        private IFood CreateFood()
        {
            string[] foodData = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodData[0];
            int foodQty = int.Parse(foodData[1]);
            IFood currFood = foodFactory.CreateFood(foodType, foodQty);

            return currFood;
        }

        private void GetInput(string command)
        {
            IAnimal currAnimal = null;

            try
            {
                currAnimal = CreateAnimal(command);
                IFood currFood = CreateFood();

                writer.WriteLine(currAnimal.ProduceSound());
                currAnimal.Eat(currFood);
            }
            catch (InvalidAnimalTypeException x)
            {
                writer.WriteLine(x.Message);
            }
            catch (InvalidFoodTypeException x)
            {
                writer.WriteLine(x.Message);
            }
            catch (FoodTypeNotEatenException x)
            {
                writer.WriteLine(x.Message);
            }
            catch (Exception)
            {
                throw;
            }

            animals.Add(currAnimal);
        }

        private void PrintResults()
        {
            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal);
            }
        }
    }
}