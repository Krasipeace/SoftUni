using System.Globalization;

using Newtonsoft.Json;

using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTOs.Import;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        //string exportToJson = GetLocalSuppliers(context);
        //string exportFilePath = @"../../../Results/local-suppliers.json";
        //File.WriteAllText(exportFilePath, exportToJson);

        //// Export Cars With Their List Of Parts
        //string exportToJson = GetCarsWithTheirListOfParts(context);
        //string exportFilePath = @"../../../Results/cars-and-parts.json";
        //File.WriteAllText(exportFilePath, exportToJson);

        //// Export Total Sales By Customer 
        //string exportToJson = GetTotalSalesByCustomer(context);
        //string exportFilePath = @"../../../Results/customers-total-sales.json";
        //File.WriteAllText(exportFilePath, exportToJson);

        //// Export Sales with Appllied Discount 
        string exportToJson = GetSalesWithAppliedDiscount(context);
        string exportFilePath = @"../../../Results/sales-discounts.json";
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

    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Cars
            .Select(c => new
            {
                car = new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                },
                parts = c.PartsCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2"),
                    })
            })
            .ToArray(), Formatting.Indented);

    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var sales = context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count(),
                prices = c.Sales
                    .SelectMany(p => p.Car.PartsCars
                        .Select(p => p.Part.Price))
            })
            .ToArray();
        var totalSales = sales
            .Select(s => new
            {
                fullName = s.fullName,
                boughtCars = s.boughtCars,
                spentMoney = s.prices.Sum()
            })
            .OrderByDescending(s => s.spentMoney)
            .ThenByDescending(s => s.boughtCars)
            .ToArray();

        return JsonConvert.SerializeObject(totalSales, Formatting.Indented);
    }

    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    { 
        var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100):f2}"
                })                
                .ToArray();

        return  JsonConvert.SerializeObject(sales, Formatting.Indented);
    }
}