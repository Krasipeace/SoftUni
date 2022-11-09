
namespace WildFarm.Factories
{
    using Contracts;
    using Exceptions;
    using Models.FoodTypes;
    using Models.Contracts;

    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, int quantity)
        {
            IFood food = type switch
            {
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                "Vegetable" => new Vegetable(quantity),
                _ => throw new InvalidFoodTypeException(),
            };

            return food;
        }
    }
}
