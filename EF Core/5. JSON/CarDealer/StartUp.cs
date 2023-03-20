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
        //string inputSuppliersFromFile = @"../../../Datasets/suppliers.json";
        //string readSuppliersFromFile = File.ReadAllText(inputSuppliersFromFile);
        //string importSuppliersToDB = ImportSuppliers(context, readSuppliersFromFile);
        //Console.WriteLine(importSuppliersToDB);

        // Import Parts
        string inputPartsFromFIle = @"../../../Datasets/parts.json";
        string readPartsFromFile = File.ReadAllText(inputPartsFromFIle);
        string importPartsToDB = ImportParts(context, readPartsFromFile);
        Console.WriteLine(importPartsToDB);
    }

    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}.";
    }

    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        var existingSuppliers = context.Suppliers
            .Select(s => s.Id)
            .ToArray();

        var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
            .Where(p => existingSuppliers
                .Contains(p.SupplierId))
            .ToList();
        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}.";
    }
}