using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split("/");
                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                double weightOrHorsePower = double.Parse(tokens[3]);

                switch (type)
                {
                    case "Car":
                        GetCar(catalog, brand, model, weightOrHorsePower);
                        break;
                    case "Truck":
                        GetTruck(catalog, brand, model, weightOrHorsePower);
                        break;
                }

                command = Console.ReadLine();
            }

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine($"Cars:");
                foreach (Car car in catalog.Cars.OrderBy(car => car.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks:");
                foreach (Truck truck in catalog.Trucks.OrderBy(truck => truck.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }

        private static void GetTruck(Catalog catalog, string brand, string model, double weightOrHorsePower)
        {
            Truck truck = new Truck();
            truck.Brand = brand;
            truck.Model = model;
            truck.Weight = weightOrHorsePower;
            catalog.Trucks.Add(truck);
        }

        private static void GetCar(Catalog catalog, string brand, string model, double weightOrHorsePower)
        {
            Car car = new Car();
            car.Brand = brand;
            car.Model = model;
            car.HorsePower = weightOrHorsePower;
            catalog.Cars.Add(car);
        }
    }
}
