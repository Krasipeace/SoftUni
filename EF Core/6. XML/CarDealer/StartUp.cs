﻿namespace CarDealer;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();
        ////Database reset
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();
        //Console.WriteLine("Database CarDealer created...");

        //Import Suppliers
        //string inputSuppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
        //string result = ImportSuppliers(context, inputSuppliers);
        //Console.WriteLine(result);

        ////Import Parts
        //string inputParts = File.ReadAllText("../../../Datasets/parts.xml");
        //string result2 = ImportParts(context, inputParts);
        //Console.WriteLine(result2);

        ////Import Cars 
        //string inputCars = File.ReadAllText("../../../Datasets/cars.xml");
        //string result3 = ImportCars(context, inputCars);
        //Console.WriteLine(result3);

        ////Import Customers 
        //string inputCustomers = File.ReadAllText("../../../Datasets/customers.xml");
        //string result4 = ImportCustomers(context, inputCustomers);
        //Console.WriteLine(result4);

        ////Import Sales 
        //string inputSales = File.ReadAllText("../../../Datasets/customers.xml");
        //string result5 = ImportCustomers(context, inputSales);
        //Console.WriteLine(result5);

        ////Export Cars with Distance
        //string result6 = GetCarsWithDistance(context);
        //Console.WriteLine(result6);

        //// Export Cars from Make BMW
        //string result7 = GetCarsFromMakeBmw(context);
        //Console.WriteLine(result7);

        //// Export Local Suppliers
        string result8 = GetLocalSuppliers(context);
        Console.WriteLine(result8);

        //// Export Cars with their list of parts
        //string result9 = GetCarsWithTheirListOfParts(context);
        //Console.WriteLine(result9);
    }

    // Import Data
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper xmlHelper = new XmlHelper();
        ImportSupplierDTO[] supplierDtos = xmlHelper.Deserialize<ImportSupplierDTO[]>(inputXml, "Suppliers");
        ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

        foreach (ImportSupplierDTO supplierDto in supplierDtos)
        {
            if (string.IsNullOrEmpty(supplierDto.Name))
            {
                continue;
            }

            Supplier supplier = mapper.Map<Supplier>(supplierDto);

            validSuppliers.Add(supplier);
        }

        context.Suppliers.AddRange(validSuppliers);
        context.SaveChanges();

        return $"Successfully imported {validSuppliers.Count}";
    }

    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportPartDto[] partDtos =
            xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

        ICollection<Part> validParts = new HashSet<Part>();
        foreach (ImportPartDto partDto in partDtos)
        {
            if (string.IsNullOrEmpty(partDto.Name))
            {
                continue;
            }

            if (!partDto.SupplierId.HasValue ||
                !context.Suppliers.Any(s => s.Id == partDto.SupplierId))
            {
                // Missing or wrong supplier id
                continue;
            }

            Part part = mapper.Map<Part>(partDto);
            validParts.Add(part);
        }

        context.Parts.AddRange(validParts);
        context.SaveChanges();

        return $"Successfully imported {validParts.Count}";
    }

    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportCarDto[] carDtos =
            xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

        ICollection<Car> validCars = new HashSet<Car>();
        foreach (ImportCarDto carDto in carDtos)
        {
            if (string.IsNullOrEmpty(carDto.Make) ||
                string.IsNullOrEmpty(carDto.Model))
            {
                continue;
            }

            Car car = mapper.Map<Car>(carDto);

            foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
            {
                if (!context.Parts.Any(p => p.Id == partDto.PartId))
                {
                    continue;
                }

                PartCar carPart = new PartCar()
                {
                    PartId = partDto.PartId
                };
                car.PartsCars.Add(carPart);
            }

            validCars.Add(car);
        }

        context.Cars.AddRange(validCars);
        context.SaveChanges();

        return $"Successfully imported {validCars.Count}";
    }

    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportCustomerDto[] customerDtos =
            xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

        ICollection<Customer> validCustomers = new HashSet<Customer>();

        foreach (ImportCustomerDto customerDto in customerDtos)
        {
            if (string.IsNullOrEmpty(customerDto.Name) ||
                string.IsNullOrEmpty(customerDto.BirthDate))
            {
                continue;
            }

            Customer customer = mapper.Map<Customer>(customerDto);
            validCustomers.Add(customer);
        }

        context.Customers.AddRange(validCustomers);
        context.SaveChanges();

        return $"Successfully imported {validCustomers.Count}";
    }

    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportSaleDto[] saleDtos =
            xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

        ICollection<int> dbCarIds = context.Cars
            .Select(c => c.Id)
            .ToArray();

        ICollection<Sale> validSales = new HashSet<Sale>();

        foreach (ImportSaleDto saleDto in saleDtos)
        {
            if (!saleDto.CarId.HasValue ||
                dbCarIds.All(id => id != saleDto.CarId.Value))
            {
                continue;
            }

            Sale sale = mapper.Map<Sale>(saleDto);
            validSales.Add(sale);
        }

        context.Sales.AddRange(validSales);
        context.SaveChanges();

        return $"Successfully imported {validSales.Count}";
    }

    // Export Data
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ExportCarWithRangeDto[] cars = context.Cars
            .Where(c => c.TraveledDistance > 2000000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ProjectTo<ExportCarWithRangeDto>(mapper.ConfigurationProvider)
            .ToArray();

        return xmlHelper.Serialize<ExportCarWithRangeDto[]>(cars, "cars");
    }

    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ExportMakeBmwCarDto[] cars = context.Cars
            .Where(c => c.Make.ToUpper() == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ProjectTo<ExportMakeBmwCarDto>(mapper.ConfigurationProvider)
            .ToArray();

        return xmlHelper.Serialize<ExportMakeBmwCarDto[]>(cars, "cars");
    }

    public static string GetLocalSuppliers(CarDealerContext context)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper XmlHelper = new XmlHelper();

            
    }

    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        IMapper mapper = InitializeAutoMapper();
        XmlHelper XmlHelper = new XmlHelper();

        ExportCarWithPartsDto[] cars = context
            .Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
            .ToArray();

        return XmlHelper.Serialize(cars, "cars");
    }

    // Automapper
    private static IMapper InitializeAutoMapper()
        => new Mapper(new MapperConfiguration(cfg
            =>
        { cfg.AddProfile<CarDealerProfile>(); }));
}