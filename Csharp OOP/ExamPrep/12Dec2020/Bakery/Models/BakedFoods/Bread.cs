namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        private const int PORTION = 200;
        public Bread(string name, decimal price) : base(name, PORTION, price)
        {
        }
    }
}
