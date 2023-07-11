namespace ProductsApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ProductsApi.Data.Models;
    using ProductsApi.Services.Contracts;

    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets a list of all products
        /// </summary>
        ///<returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return this.Ok(this.productService.GetAllProducts());
        }

        /// <summary>
        /// Gets a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = this.productService.GetById(id);

            if (product == null)
            {
                return this.NotFound();
            }

            return this.Ok(product);
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        ///<returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
        public ActionResult<Product> PostProduct(Product product)
        {
            Product createdProduct = this.productService
                .CreateProduct(product.Name, product.Description);

            return this.CreatedAtAction(nameof(this.GetProduct), new
            {
                id = createdProduct.Id
            },
            createdProduct);
        }

        /// <summary>
        /// Edits a product.
        /// </summary>
        ///<returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }

            this.productService.EditProduct(id, product);

            return NoContent();
        }

        /// <summary>
        /// Edits a product partially.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        ///<returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public IActionResult PatchProduct(int id, Product product)
        {
            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }

            this.productService.EditProductPartially(id, product);

            return NoContent();
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        ///<returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public ActionResult<Product> DeleteProduct(int id)
        {
            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }

            var product = this.productService.DeleteProduct(id);

            return product;
        }
    }
}
