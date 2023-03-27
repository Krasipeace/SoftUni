namespace ProductShop;

using System.Xml.Serialization;

using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

public class StartUp
{
    public static void Main()
    {
        // db reset
        ProductShopContext context = new ProductShopContext();
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();
        //Console.WriteLine("Database ProductShop created...");

        // Import Users 
        string inputUsers = File.ReadAllText("../../../Datasets/users.xml");
        string result = ImportUsers(context, inputUsers);
        Console.WriteLine(result);

        // Import Products
        string inputProducts = File.ReadAllText("../../../Datasets/products.xml");
        string result2 = ImportProducts(context, inputProducts);
        Console.WriteLine(result2);

        // Import Categories 
        string inputCategories = File.ReadAllText("../../../Datasets/categories.xml");
        string result3 = ImportCategories(context, inputCategories);
        Console.WriteLine(result3);

        // Import Categories and Products 
        string inputCategoriesAndProducts = File.ReadAllText("../../../Datasets/categories-products.xml");
        string result4 = ImportCategoryProducts(context, inputCategoriesAndProducts);
        Console.WriteLine(result4);
    }

    // Import Data
    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        var importUsers = Deserialize<ImportUsersDto[]>(inputXml, "Users");

        var users = importUsers
            .Select(u => new User()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age <= 0
                    ? null
                    : u.Age
            })
            .ToArray();

        return $"Successfully imported {users.Count()}";
    }

    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        var importProducts = Deserialize<ImportProductsDto[]>(inputXml, "Products");

        var products = importProducts
            .Select(p => new Product()
            {
                Name = p.Name,
                Price = p.Price,
                BuyerId = p.BuyerId == 0
                    ? null
                    : p.BuyerId,
                SellerId = p.SellerId
            })
            .ToArray();

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count()}";
    }

    public static string ImportCategories(ProductShopContext context, string inputXml)
    {
        var importCategories = Deserialize<ImportCategoriesDto[]>(inputXml, "Categories");

        var categories = importCategories
            .Where(c => c.Name != null)
            .Select(c => new Category()
            {
                Name = c.Name
            })
            .ToArray();

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count()}";
    }

    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
    {
        var importCategoriesProducts = Deserialize<ImportCategoriesProductsDto[]>(inputXml, "CategoryProducts");
        var categoriesProducts = importCategoriesProducts
            .Where(cp => context.Categories
                .Any(c => c.Id == cp.CategoryId) &&
                    context.Products.Any(p => p.Id == cp.ProductId))
            .Select(cp => new CategoryProduct()
            {
                CategoryId = cp.CategoryId,
                ProductId = cp.ProductId
            })
            .ToArray();

        context.CategoryProducts.AddRange(categoriesProducts);
        context.SaveChanges();

        return $"Successfully imported {categoriesProducts.Count()}";
    }

    // Deserializer
    public static T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);

        using StringReader reader = new StringReader(inputXml);

        T dtos = (T)serializer.Deserialize(reader);

        return dtos;
    }
}