namespace WildFarm.Factories
{
    using Exceptions;
    using Contracts;
    using Models.Animals;
    using Models.Contracts;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] args)
        {
            string type = args[0];
            string name = args[1];
            double weight = double.Parse(args[2]);
            string moreInfo = args[3];

            IAnimal animal = type switch
            {
                "Cat" => new Cat(name, weight, moreInfo, args[4]),
                "Dog" => new Dog(name, weight, moreInfo),
                "Hen" => new Hen(name, weight, double.Parse(moreInfo)),
                "Mouse" => new Mouse(name, weight, moreInfo),
                "Tiger" => new Tiger(name, weight, moreInfo, args[4]),
                "Owl" => new Owl(name, weight, double.Parse(moreInfo)),
                _ => throw new InvalidAnimalTypeException(),
            };

            return animal;
        }
    }
}
