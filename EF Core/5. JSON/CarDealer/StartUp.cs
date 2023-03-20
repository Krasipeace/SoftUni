using Newtonsoft.Json;

using CarDealer.Data;
using CarDealer.Models;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();
        //Database reset
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();
        //Console.WriteLine("Database CarDealer created...");

        // Import Suppliers 
        string inputSuppliersFromFile = @"../../../Datasets/suppliers.json";
        string readSuppliersFromFile = File.ReadAllText(inputSuppliersFromFile);
        string importSuppliersToDB = ImportSuppliers(context, readSuppliersFromFile);
        Console.WriteLine(importSuppliersToDB);

    }

    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}.";
    }
}