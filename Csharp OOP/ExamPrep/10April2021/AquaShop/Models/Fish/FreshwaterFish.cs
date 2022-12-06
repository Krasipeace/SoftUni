namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int INITIAL_SIZE = 3;
        private const int SIZE_MODIFIER = 3;
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            Size = INITIAL_SIZE;
        }

        public override void Eat()
        {
            Size += SIZE_MODIFIER;
        }
    }
}
