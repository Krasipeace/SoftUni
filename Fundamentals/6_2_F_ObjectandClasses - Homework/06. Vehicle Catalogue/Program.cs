using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    enum VehicleType
    {
        Car,
        Truck
    }
    class Vehicle
    {
        public Vehicle(VehicleType type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsePower;
        }
        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"Type: {Type}");
            output.AppendLine($"Model: {Model}");
            output.AppendLine($"Color: {Color}");
            output.AppendLine($"Horsepower: {Horsepower}");

            return output.ToString().TrimEnd();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            var vehicles = new List<Vehicle>();

            command = VehicleAdd(command, vehicles);

            VehicleCatalog(vehicles);

            CheckAndPrintOutputs(vehicles);
        }

        private static void CheckAndPrintOutputs(List<Vehicle> vehicles)
        {
            var cars = vehicles.Where(x => x.Type == VehicleType.Car).ToList();
            var trucks = vehicles.Where(t => t.Type == VehicleType.Truck).ToList();

            var carsAvgHorsePower = cars.Count > 0 ? cars.Average(hp => hp.Horsepower) : 0.00;
            var trucksAvgHorsePower = trucks.Count > 0 ? trucks.Average(hp => hp.Horsepower) : 0.00;

            Console.WriteLine($"Cars have average horsepower of: {carsAvgHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvgHorsePower:f2}.");
        }

        private static void VehicleCatalog(List<Vehicle> vehicles)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Close the Catalogue")
                {
                    break;
                }
                var vehicleToCheck = vehicles.FirstOrDefault(x => x.Model == input);

                Console.WriteLine(vehicleToCheck);
            }
        }

        private static string[] VehicleAdd(string[] command, List<Vehicle> vehicles)
        {
            while (command[0] != "End")
            {
                VehicleType type;

                bool isSuccessfull = Enum.TryParse(command[0], true, out type);

                if (isSuccessfull)
                {
                    string model = command[1];
                    string color = command[2];
                    int horsePower = int.Parse(command[3]);

                    var vehicle = new Vehicle(type, model, color, horsePower);
                    vehicles.Add(vehicle);
                }
                command = Console.ReadLine().Split();
            }

            return command;
        }
    }
}
