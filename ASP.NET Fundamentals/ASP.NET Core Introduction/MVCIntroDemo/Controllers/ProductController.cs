using System.Text;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

using MVCIntroDemo.Models.Product;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = products
                    .Where(p => p.Name
                        .ToLower()
                        .Contains(keyword.ToLower()));

                return View(foundProducts);
            }

            return View(products);
        }

        public IActionResult ById(int id)
        {
            var product = products
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var text = string.Empty;
            foreach (var product in products)
            {
                text += $"Product {product.Id}: {product.Name}  - {product.Price:f2} lv.{Environment.NewLine}";
            }

            return Content(text);
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new();
            foreach (var product in products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name}  - {product.Price:f2} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }

        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00m
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50m
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50m
            }
        };
    }
}
