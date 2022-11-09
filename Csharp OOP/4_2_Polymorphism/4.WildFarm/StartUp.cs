namespace WildFarm
{
    using Core;
    using Core.Contracts;
    using Factories;
    using Factories.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();
            IEngine engine = new Engine(reader, writer, animalFactory, foodFactory);
            engine.Run();
        }
    }
}
