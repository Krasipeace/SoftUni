using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            AddNewCar(cars);

            CheckCargo(cars);
        }

        private static void AddNewCar(List<Car> cars)
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                cars.Add(new Car(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)));
            }
        }

        private static void CheckCargo(List<Car> cars)
        {
            string cargoType = Console.ReadLine();

            if (cargoType == "fragile")
            {
                CheckFragileCars(cars);
            }
            else if (cargoType == "flamable")
            {
                CheckFlammableCars(cars);
            }
        }
        private static void CheckFragileCars(List<Car> cars)
        {
            foreach (var car in cars.Where(currCar => currCar.CarsCargo.Type == "fragile" && currCar.CarsCargo.Weigth < 1000))
            {
                Console.WriteLine($"{car.Model}");
            }
        }
        private static void CheckFlammableCars(List<Car> cars)
        {
            foreach (var car in cars.Where(currCar => currCar.CarsCargo.Type == "flamable" && currCar.CarsEngine.Power > 250))
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine CarsEngine { get; set; }
        public Cargo CarsCargo { get; set; }
        public Car(string[] carInfo)
        {
            Model = carInfo[0];
            CarsEngine = new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2]));
            CarsCargo = new Cargo(int.Parse(carInfo[3]), carInfo[4]);
        }
    }
    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }
    class Cargo
    {
        public int Weigth { get; set; }
        public string Type { get; set; }
        public Cargo(int weight, string type)
        {
            Weigth = weight;
            Type = type;
        }
    }
}
