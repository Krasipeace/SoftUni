namespace ProductShop;

using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using ProductShop.Data;
using DTOs.Import;
using ProductShop.Models;
using System.Collections;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

public class StartUp
{
    private static string filePath;

    public static void Main()
    {
        ProductShopContext psContext = new ProductShopContext();

        // Database reset
        psContext.Database.EnsureDeleted();
        psContext.Database.EnsureCreated();
        Console.WriteLine("Database created");

        //Import Users
        string inputJson = File.ReadAllText("../../../Datasets/users.json");
        string result = ImportUsers(psContext, inputJson);
        Console.WriteLine(result);

        // Import Categories
        string inputJson2 = File.ReadAllText("../../../Datasets/products.json");
        string result2 = ImportProducts(psContext, inputJson2);
        Console.WriteLine(result2);

        // Import Categories 
        //string inputJson3 = File.ReadAllText("../../../Datasets/categories.json");
        //string result3 = ImportCategories(psContext, inputJson3);
        //Console.WriteLine(result3);

        // Import Categories and Products
        string inputJson4 = File.ReadAllText("../../../Datasets/categories-products.json");
        string result4 = ImportCategoryProducts(psContext, inputJson4);
        Console.WriteLine(result4);
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
        ImportCategories[] categories = JsonConvert.DeserializeObject<ImportCategories[]>(inputJson);
        ICollection<Category> validCategories = JsonConvert.DeserializeObject<ICollection<Category>>(inputJson);

        foreach (ImportCategories currentCategory in categories)
        {
            if (!IsValid(currentCategory))
            {
                continue;
            }

            //no idea
            //validCategories.Add(currentCategory);
        }

        context.Categories.AddRange(validCategories);
        context.SaveChanges();

        return $"Successfully imported {validCategories.Count}";
    }

    // Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        ICollection<CategoryProduct> categoryProduct = JsonConvert.DeserializeObject<ICollection<CategoryProduct>>(inputJson);

        context.CategoriesProducts.AddRange(categoryProduct);
        context.SaveChanges();

        return $"Successfully imported {categoryProduct.Count}";
    }

    // Validation method
    private static bool IsValid(object obj)
    {
        var validationContext = new ValidationContext(obj);
        var validationResult = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

        return isValid;
    }
}