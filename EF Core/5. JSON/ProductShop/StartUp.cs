namespace ProductShop;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;

using ProductShop.Data;
using DTOs.Import;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    private static string filePath;

    public static void Main()
    {   
        ProductShopContext psContext = new ProductShopContext();
        psContext.Database.EnsureDeleted();
        psContext.Database.EnsureCreated();

        Console.WriteLine("Database created");

        //Import Users
        string inputJson = File.ReadAllText("../../../Datasets/users.json");
        string result = ImportUsers(psContext, inputJson);
        Console.WriteLine(result);
    }

    // Import Users
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        ImportUsers[] usersDTOs = JsonConvert.DeserializeObject<ImportUsers[]>(inputJson);
   
        ICollection<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }
}