﻿using System.Globalization;

using Newtonsoft.Json;

using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTOs.Import;

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

        //// Import Suppliers 
        //string inputSuppliersFromFile = @"../../../Datasets/suppliers.json";
        //string readSuppliersFromFile = File.ReadAllText(inputSuppliersFromFile);
        //string importSuppliersToDB = ImportSuppliers(context, readSuppliersFromFile);
        //Console.WriteLine(importSuppliersToDB);

        //// Import Parts
        //string inputPartsFromFIle = @"../../../Datasets/parts.json";
        //string readPartsFromFile = File.ReadAllText(inputPartsFromFIle);
        //string importPartsToDB = ImportParts(context, readPartsFromFile);
        //Console.WriteLine(importPartsToDB);

        //// Import Cars
        //string inputCarsFromFile = @"../../../Datasets/cars.json";
        //string readCarsFromFile = File.ReadAllText(inputCarsFromFile);
        //string importCarsToDB = ImportCars(context, readCarsFromFile);
        //Console.WriteLine(importCarsToDB);

        //// Import Customers
        //string inputCustomersFromFile = @"../../../Datasets/customers.json";
        //string readCustomersFromFile = File.ReadAllText(inputCustomersFromFile);
        //string importCustomersToDB = ImportCustomers(context, readCustomersFromFile);
        //Console.WriteLine(importCustomersToDB);

        //// Import Sales
        //string inputSalesFromFile = @"../../../Datasets/sales.json";
        //string readSalesFromFile = File.ReadAllText(inputSalesFromFile);
        //string importSalesToDB = ImportSales(context, readSalesFromFile);
        //Console.WriteLine(importSalesToDB);

        //// Export Ordered Customers
        //string exportToJson = GetOrderedCustomers(context);
        //string exportFilePath = @"../../../Results/ordered-customers.json";
        //File.WriteAllText(exportFilePath, exportToJson);

        //// Export Cars from Make Toyota
        //string exportToJson = GetCarsFromMakeToyota(context);
        //string exportFilePath = @"../../../Results/toyota-cars.json";
        //File.WriteAllText(exportFilePath, exportToJson);

        //// Export Local Suppliers
        string exportToJson = GetLocalSuppliers(context);
        string exportFilePath = @"../../../Results/local-suppliers.json";
        File.WriteAllText(exportFilePath, exportToJson);
    }

    // Import Data
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

    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var carsWithParts = JsonConvert.DeserializeObject<List<ImportCarsDTO>>(inputJson);
        var parts = new List<PartCar>();
        var cars = new List<Car>();

        foreach (var car in carsWithParts)
        {
            Car importCar = new Car()
            {
                Make = car.Make,
                Model = car.Model,
                TraveledDistance = car.TraveledDistance
            };
            cars.Add(importCar);

            foreach (var part in car.PartsId.Distinct())
            {
                PartCar importPart = new PartCar()
                {
                    Car = importCar,
                    PartId = part
                };
                parts.Add(importPart);
            }
        }

        context.Cars.AddRange(cars);
        context.PartsCars.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }

    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}.";
    }

    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}.";
    }

    // Export Data
    public static string GetOrderedCustomers(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .Select(c => new
            {
                Name = c.Name,
                BirthDate = c.BirthDate.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture),
                IsYoungDriver = c.IsYoungDriver,
            })
            .ToArray(), Formatting.Indented);

    public static string GetCarsFromMakeToyota(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Cars
            .Where(c => c.Make == "Toyota")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .Select(c => new
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .ToArray(), Formatting.Indented);

    public static string GetLocalSuppliers(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray(), Formatting.Indented);
}