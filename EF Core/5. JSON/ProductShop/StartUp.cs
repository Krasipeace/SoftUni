﻿namespace ProductShop;

using System.Collections.Generic;
using System.IO;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using ProductShop.Data;
using DTOs.Import;
using ProductShop.Models;
using AutoMapper.QueryableExtensions;
using ProductShop.DTOs.Export;
using AutoMapper;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext psContext = new ProductShopContext();

        // Database reset
        psContext.Database.EnsureDeleted();
        psContext.Database.EnsureCreated();
        Console.WriteLine("Database created");

        // Import Users
        string inputJson = File.ReadAllText("../../../Datasets/users.json");
        string result = ImportUsers(psContext, inputJson);
        Console.WriteLine(result);

        // Import Products
        string inputJson2 = File.ReadAllText("../../../Datasets/products.json");
        string result2 = ImportProducts(psContext, inputJson2);
        Console.WriteLine(result2);

        // Import Categories 
        string inputJson3 = File.ReadAllText("../../../Datasets/categories.json");
        string result3 = ImportCategories(psContext, inputJson3);
        Console.WriteLine(result3);

        // Import Categories and Products
        string inputJson4 = File.ReadAllText("../../../Datasets/categories-products.json");
        string result4 = ImportCategoryProducts(psContext, inputJson4);
        Console.WriteLine(result4);

        // Export Products in Range
        string exportJson1 = GetProductsInRange(psContext);
        Console.WriteLine(exportJson1);
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
}