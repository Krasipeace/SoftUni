using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            AddNewCar(cars, lines);

            string input = DriveUserCar(cars);

            PrintResult(cars);
        }

        private static void PrintResult(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }

        private static string DriveUserCar(List<Car> cars)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] userCommands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (userCommands[0] == "Drive")
                {
                    string model = userCommands[1];
                    int distance = int.Parse(userCommands[2]);

                    int index = cars.FindIndex(currCar => currCar.Model == model);
                    cars[index].DriveCar(distance);
                }
            }

            return input;
        }

        private static void AddNewCar(List<Car> cars, int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] inputCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string newModel = inputCar[0];
                double fuel = double.Parse(inputCar[1]);
                double fuelConsumption = double.Parse(inputCar[2]);

                Car newCar = new Car(newModel, fuel, fuelConsumption);
                cars.Add(newCar);
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double Distance { get; set; }

        public Car(string model, double fuel, double consumption)
        {
            Model = model;
            FuelAmount = fuel;
            FuelConsumption = consumption;
        }
        public void DriveCar(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (FuelAmount >= fuelNeeded)
            {
                Distance += distance;
                FuelAmount -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
