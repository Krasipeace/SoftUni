using ShoppingList.Data.Models;

namespace ShoppingList.Models.Product
{

    public class ProductFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        
        public string Content { get; set; } = null!;
    }
}
