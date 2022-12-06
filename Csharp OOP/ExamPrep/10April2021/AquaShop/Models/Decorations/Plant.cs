namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int COMFORT = 1;
        private const decimal PRICE = 5;
        public Plant() : base(COMFORT, PRICE)
        {
        }
    }
}
