using ShoppingList.Data.Models;

namespace ShoppingList.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
