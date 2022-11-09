namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;
    using Contracts;
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract double WeightModifier { get; }
        public abstract IReadOnlyCollection<Type> CorrectFood { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!CorrectFood.Any(x => food.GetType().Name == x.Name))
            {
                throw new FoodTypeNotEatenException(string.Format(ExceptionMessages.NOT_THE_CORRECT_TYPE_FOOD, GetType().Name, food.GetType().Name));
            }

            Weight += food.Quantity * WeightModifier;
            FoodEaten += food.Quantity;
        }

        public override string ToString() => $"{GetType().Name} [{Name}, ";
    }
}
