using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            List<Car> specialCars = new List<Car>();

            Tires(tires);

            Engines(engines);

            ShowSpecialCars(tires, engines, cars);

            CheckAndPrintSpecialCars(cars, specialCars);
        }

        private static void Tires(List<Tire[]> tires)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }

                string[] tiresInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<Tire> tiresList = new List<Tire>();

                for (int i = 0; i < tiresInfo.Length; i += 2)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i + 1]);
                    Tire tire = new Tire(year, pressure);
                    tiresList.Add(tire);
                }

                tires.Add(tiresList.ToArray());
            }
        }

        private static void Engines(List<Engine> engines)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }

                string[] engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }
        }

        private static void ShowSpecialCars(List<Tire[]> tires, List<Engine> engines, List<Car> cars)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;
                }

                string[] carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }
        }

        private static void CheckAndPrintSpecialCars(List<Car> cars, List<Car> specialCars)
        {
            Func<Car, bool> filter = c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10;

            foreach (Car car in cars.Where(filter))
            {
                car.Drive(20);
                specialCars.Add(car);
            }

            Console.WriteLine(string.Join("", specialCars));
        }
    }
}
