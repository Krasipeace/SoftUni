namespace AquaShop.Models.Fish
{
    using AquaShop.Models.Fish.Contracts;
    public class SaltwaterFish : Fish
    {
        private const int INITIAL_SIZE = 5;
        private const int SIZE_MODIFIER = 2;
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            Size = INITIAL_SIZE;
        }

        public override void Eat()
        {
            Size += SIZE_MODIFIER;
        }
    }
}
