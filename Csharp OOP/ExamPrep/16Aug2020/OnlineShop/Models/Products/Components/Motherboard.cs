namespace OnlineShop.Models.Products.Components
{
    public class Motherboard : Component
    {
        private const double OVERALL_PERFORMANCE = 1.25;

        public Motherboard(int id, string manufacturer, string model, decimal price, int generation) : base(id, manufacturer, model, price, OVERALL_PERFORMANCE, generation)
        {
        }
    }
}
