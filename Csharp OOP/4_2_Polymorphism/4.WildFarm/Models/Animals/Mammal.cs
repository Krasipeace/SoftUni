namespace WildFarm.Models.Animals
{
    using Contracts;
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, string livingRegion) : base (name, weight)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; private set; }
    }
}
