namespace ProductShop;

using System.Text;
using System.Xml.Serialization;

using ProductShop.Data;
using ProductShop.DTOs.Export;
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

        // Export Categories in Range
        Console.WriteLine(GetProductsInRange(context));

        // Export Sold Products 
        Console.WriteLine(GetSoldProducts(context));

        // Export Categories by Products Count
        Console.WriteLine(GetCategoriesByProductsCount(context));

        // Export Users and Products
        Console.WriteLine(GetCategoriesByProductsCount(context));
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

        context.Users.AddRange(users);
        context.SaveChanges();

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

    // Export Data
    public static string GetProductsInRange(ProductShopContext context)
    {
        var productsInRange = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Take(10)
            .Select(p => new ExportProductsDto()
            {
                Name = p.Name,
                Price = p.Price,
                BuyerName = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
            })
            .ToArray();

        return Serialize(productsInRange, "Products");
    }

    public static string GetSoldProducts(ProductShopContext context)
    {
        var soldProducts = context.Users
            .Where(u => u.ProductsSold.Any())
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new ExportUsersDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                SoldProducts = u.ProductsSold
                    .Select(p => new ExportSoldProductsDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                .ToArray()
            })
            .Take(5)
            .ToArray();

        return Serialize(soldProducts, "Users");
    }

    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .Select(c => new ExportCategoriesDto()
            {
                Name = c.Name,
                Count = c.CategoryProducts.Count,
                AveragePrice = c.CategoryProducts
                    .Average(cp => cp.Product.Price),
                TotalRevenue = c.CategoryProducts
                    .Sum(cp => cp.Product.Price)
            })
            .OrderByDescending(c => c.Count)
            .ThenBy(c => c.TotalRevenue)
            .ToArray();

        return Serialize(categories, "Categories");
    }

    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context
            .Users
            .Where(u => u.ProductsSold.Any())
            .OrderByDescending(u => u.ProductsSold.Count)
            .Select(u => new ExportUserFullInfoDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                SoldProducts = new SoldProductsCount()
                {
                    Count = u.ProductsSold.Count,
                    Products = u.ProductsSold.Select(p => new ExportSoldProductsDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                }
            })
            .Take(10)
            .ToArray();

        ExportUserCountDto exportUserCountDto = new ExportUserCountDto()
        {
            Count = context.Users.Count(u => u.ProductsSold.Any()),
            Users = users
        };

        return Serialize(exportUserCountDto, "Users");
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

    // Serializer 
    public static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

        StringBuilder sb = new StringBuilder();
        using var write = new StringWriter(sb);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(string.Empty, string.Empty);

        serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

        return sb.ToString();
    }
}