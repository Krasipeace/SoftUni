namespace ProductShop;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Data;
using DTOs.Export;
using DTOs.Import;
using Models;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext psContext = new ProductShopContext();

        // Database reset
        //psContext.Database.EnsureDeleted();
        //psContext.Database.EnsureCreated();
        //Console.WriteLine("Database created");

        //// Import Users
        //string inputJson = File.ReadAllText("../../../Datasets/users.json");
        //string result = ImportUsers(psContext, inputJson);
        //Console.WriteLine(result);

        //// Import Products
        //string inputJson2 = File.ReadAllText("../../../Datasets/products.json");
        //string result2 = ImportProducts(psContext, inputJson2);
        //Console.WriteLine(result2);

        //// Import Categories 
        //string inputJson3 = File.ReadAllText("../../../Datasets/categories.json");
        //string result3 = ImportCategories(psContext, inputJson3);
        //Console.WriteLine(result3);

        //// Import Categories and Products
        //string inputJson4 = File.ReadAllText("../../../Datasets/categories-products.json");
        //string result4 = ImportCategoryProducts(psContext, inputJson4);
        //Console.WriteLine(result4);

        //// Export Products in Range
        //string exportJson1 = GetProductsInRange(psContext);
        //Console.WriteLine(exportJson1);

        //// Export Sold Products
        //string exportJson2 = GetSoldProducts(psContext);
        //Console.WriteLine(exportJson2);

        // Export Categories by Products Count
        //string exportJson3 = GetCategoriesByProductsCount(psContext);
        //Console.WriteLine(exportJson3);

        // Export Users and Products
        string exportJson4 = GetUsersWithProducts(psContext);
        Console.WriteLine(exportJson4);
    }

    // Import Users
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        ICollection<User> users = JsonConvert.DeserializeObject<ICollection<User>>(inputJson);

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }

    // Import Products
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        ICollection<Product> products = JsonConvert.DeserializeObject<ICollection<Product>>(inputJson);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    // Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        ICollection<Category> categories = JsonConvert.DeserializeObject<ICollection<Category>>(inputJson).Where(c => c.Name != null).ToList();

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    // Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        ICollection<CategoryProduct> categoryProduct = JsonConvert.DeserializeObject<ICollection<CategoryProduct>>(inputJson);

        context.CategoriesProducts.AddRange(categoryProduct);
        context.SaveChanges();

        return $"Successfully imported {categoryProduct.Count}";
    }

    // Export Products in Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        var exportProductsInRange = context
            .Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new
            {
                name = p.Name,
                price = p.Price,
                seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
            })
            .ToArray();

        return JsonConvert.SerializeObject(exportProductsInRange, Formatting.Indented);
    }

    // Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        var exportSoldProducts = context
            .Users
            .Where(u => u.ProductsSold.Any(b => b.Buyer != null))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                soldProducts = u.ProductsSold.Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    buyerFirstName = p.Buyer.FirstName,
                    buyerLastName = p.Buyer.LastName,
                })
            })
            .ToArray();

        return JsonConvert.SerializeObject(exportSoldProducts, Formatting.Indented);
    }

    // Export Categories by Products Count
    // still 0/100
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();

        var categories = context.Categories
            .OrderByDescending(c => c.CategoriesProducts.Count)
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count,
                AveragePrice = Math.Round((double)c.CategoriesProducts.Average(p => p.Product.Price), 2),
                TotalRevenue = Math.Round((double)c.CategoriesProducts.Sum(p => p.Product.Price), 2)
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(categories,
            Formatting.Indented,
            new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });
    }

    // Export Users with Products
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();

        var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.ProductsSold
                        .Count(p => p.Buyer != null),
                    Products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToArray()
                }
            })
            .OrderByDescending(u => u.SoldProducts.Count)
            .AsNoTracking()
            .ToArray();

        var userWrapperDto = new
        {
            UsersCount = users.Length,
            Users = users
        };

        return JsonConvert.SerializeObject(userWrapperDto,
            Formatting.Indented,
            new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            });
    }

    public static IContractResolver ConfigureCamelCaseNaming()
    {
        return new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy(false, true)
        };
    }
}