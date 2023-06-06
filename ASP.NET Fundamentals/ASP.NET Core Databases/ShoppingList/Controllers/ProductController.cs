using Microsoft.AspNetCore.Mvc;

using ShoppingList.Data;
using ShoppingList.Data.Models;
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

        [HttpGet]
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductFormModel product)
        {
            var productData = new Product()
            {
                Name = product.Name
            };

            data.Products.Add(productData);
            data.SaveChanges();

            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = data.Products.Find(id);

            return View(new ProductFormModel()
            {
                Name = product.Name
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            var productData = data.Products.Find(id);
            productData.Name = model.Name;

            data.SaveChanges();

            return RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = data.Products.Find(id);

            data.Products.Remove(product);
            data.SaveChanges();

            return RedirectToAction("All");
        }
    }
}
