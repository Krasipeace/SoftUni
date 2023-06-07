using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductFormModel()
            {
                Name = product.Name
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, Product model, string noteContent)
        {
            var productData = data.Products
                .Include(p => p.ProductNotes)
                .FirstOrDefault(p => p.Id == id);

            if (productData != null)
            {
                productData.Name = model.Name;

                if (!string.IsNullOrEmpty(noteContent))
                {
                    var note = new ProductNote
                    {
                        Content = noteContent
                    };

                    productData.ProductNotes.Add(note);
                }

                data.SaveChanges();
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = data.Products.Find(id);

            if (product != null)
            {
                data.Products.Remove(product);
                data.SaveChanges();
            }

            return RedirectToAction("All");
        }
    }
}
