namespace ProductsApi.Services
{
    using System.Collections.Generic;

    using ProductsApi.Data;
    using ProductsApi.Data.Models;
    using ProductsApi.Services.Contracts;

    public class ProductService : IProductService
    {
        private readonly ProductDbContext dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }  

        public IList<Product> GetAllProducts()
        {
            return this.dbContext.Products.ToArray();
        }

        public Product? GetById(int id)
        {
            return this.dbContext.Products.Find(id);
        }

        public Product CreateProduct(string name, string description)
        {
            Product product = new ()
            {
                Name = name,
                Description = description
            };

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();

            return product;
        }

        public void EditProduct(int id, Product product)
        {
            var dbProduct = this.dbContext.Products.Find(id);

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;

            this.dbContext.SaveChanges();
        }

        public void EditProductPartially(int id, Product product)
        {
            var dbProduct = this.dbContext.Products.Find(id);

            dbProduct.Name = String.IsNullOrEmpty(product.Name) 
                ? dbProduct.Name 
                : product.Name;

            dbProduct.Description = String.IsNullOrEmpty(product.Description) 
                ? dbProduct.Description 
                : product.Description;

            this.dbContext.SaveChanges();
        }

        public Product DeleteProduct(int id)
        {
            var product = this.dbContext.Products.Find(id);

            this.dbContext.Products.Remove(product);
            this.dbContext.SaveChanges();

            return product;
        }
    }
}
