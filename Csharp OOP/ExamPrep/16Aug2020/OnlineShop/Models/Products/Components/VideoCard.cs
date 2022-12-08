namespace OnlineShop.Models.Products.Components
{
    public class VideoCard : Component
    {
        private const double OVERALL_PERFORMANCE = 1.15;

        public VideoCard(int id, string manufacturer, string model, decimal price, int generation) : base(id, manufacturer, model, price, OVERALL_PERFORMANCE, generation)
        {
        }
    }
}
