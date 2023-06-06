using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data;
using ShoppingList.Models.Product;

namespace ShoppingList.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoppingListDbContext data;

        public ProductController(ShoppingListDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var products = data
                .Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();

            return View(products);
        }
    }
}
