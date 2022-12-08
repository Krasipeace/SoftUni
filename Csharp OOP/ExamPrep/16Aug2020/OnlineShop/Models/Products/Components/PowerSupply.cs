namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        private const double OVERALL_PERFORMANCE = 1.05;

        public PowerSupply(int id, string manufacturer, string model, decimal price, int generation) : base(id, manufacturer, model, price, OVERALL_PERFORMANCE, generation)
        {
        }
    }
}
