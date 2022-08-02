using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Need_For_Speed_III_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int inputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLines; i++)
            {
                string[] carInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car()
                {
                    Name = carInfo[0],
                    Mileage = int.Parse(carInfo[1]),
                    Fuel = int.Parse(carInfo[2])
                };

                cars.Add(car);
            }           

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);              

                switch(tokens[0])
                {
                    case "Drive":
                        Drive(tokens, cars);          //Drive : {car} : {distance} : {fuel}
                        break;
                    case "Refuel":
                        Refuel(tokens, cars);         //Refuel : {car} : {fuel}
                        break;
                    case "Revert":
                        Revert(tokens, cars);         //Revert : {car} : {kilometers}
                        break;
                }
                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }

        private static void Drive(string[] tokens, List<Car> cars)
        {
            const int MAX_MILEAGE = 100000;

            string name = tokens[1];
            int distance = int.Parse(tokens[2]);
            int fuel = int.Parse(tokens[3]);

            Car car = cars.First(currCar => currCar.Name == name);

            if (fuel > car.Fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");

                return;
            }
            car.Mileage += distance;
            car.Fuel -= fuel;

            Console.WriteLine($"{name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

            if (car.Mileage >= MAX_MILEAGE)
            {
                cars.Remove(car);
                Console.WriteLine($"Time to sell the {name}!");
            }

        }

        private static void Refuel(string[] tokens, List<Car> cars)
        {
            const int MAX_FUEL = 75;

            string name = tokens[1];
            int fuel = int.Parse(tokens[2]);

            Car car = cars.First(currCar => currCar.Name == name);
            int initialFuel = car.Fuel;

            car.Fuel += fuel;

            if (car.Fuel >= MAX_FUEL)
            {
                 car.Fuel = MAX_FUEL;   
            }
            
            Console.WriteLine($"{name} refueled with {car.Fuel - initialFuel} liters");
        }

        private static void Revert(string[] tokens, List<Car> cars)
        {
            const int MIN_MILEAGE = 10000;

            string name = tokens[1];
            int kilometers = int.Parse(tokens[2]);

            Car car = cars.First(currCar => currCar.Name == name);

            car.Mileage -= kilometers;

            if (car.Mileage <= MIN_MILEAGE)
            {
                car.Mileage = MIN_MILEAGE;
            }

            Console.WriteLine($"{name} mileage decreased by {kilometers} kilometers");
        }

        class Car
        {
            public string Name { get; set; }
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
    }
}
