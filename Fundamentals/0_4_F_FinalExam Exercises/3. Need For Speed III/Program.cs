using System;
using System.Collections.Generic;

namespace _3._Need_For_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new Dictionary<string, List<int>>();

            int inputCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                string carName = carInfo[0];
                int carMileage = int.Parse(carInfo[1]);
                int carFuel = int.Parse(carInfo[2]);

                cars.Add(carName, new List<int> { carMileage, carFuel }); //{ Value[0]  ,  Value[1] }
            }

            const int MAX_FUEL = 75;
            const int MAX_MILEAGE = 100000;
            const int MIN_MILEAGE = 10000;

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string car = tokens[1];

                switch (tokens[0])
                {
                    case "Drive":
                        int distance = int.Parse(tokens[2]);
                        int dFuel = int.Parse(tokens[3]);
                        Drive(car, distance, dFuel, cars, MAX_MILEAGE);         //Drive : {car} : {distance} : {fuel}
                        break;
                    case "Refuel":
                        int fuel = int.Parse(tokens[2]);
                        Refuel(car, fuel, cars, MAX_FUEL);                      //Refuel : {car} : {fuel}
                        break;
                    case "Revert":
                        int kilometers = int.Parse(tokens[2]);
                        Revert(car, kilometers, cars, MIN_MILEAGE);             //Revert : {car} : {kilometers}
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }

        private static void Drive(string car, int distance, int dFuel, Dictionary<string, List<int>> cars, int MAX_MILEAGE)
        {
            if (cars[car][1] < dFuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");

                return;
            }
            else
            {
                cars[car][0] += distance;
                cars[car][1] -= dFuel;
                Console.WriteLine($"{car} driven for {distance} kilometers. {dFuel} liters of fuel consumed.");

                if (cars[car][0] >= MAX_MILEAGE)
                {
                    Console.WriteLine($"Time to sell the {car}!");
                    cars.Remove(car);
                }
            }
        }

        private static void Refuel(string car, int fuel, Dictionary<string, List<int>> cars, int MAX_FUEL)
        {
            int initialFuel = cars[car][1];
            cars[car][1] += fuel;

            if (cars[car][1] >= MAX_FUEL)
            {
                cars[car][1] = MAX_FUEL;
            }
            
            Console.WriteLine($"{car} refueled with {Math.Abs(cars[car][1]) - initialFuel} liters");
        }

        private static void Revert(string car, int kilometers, Dictionary<string, List<int>> cars, int MIN_MILEAGE)
        {
            cars[car][0] -= kilometers;

            if (cars[car][0] <= MIN_MILEAGE)
            {
                cars[car][0] = MIN_MILEAGE;
            }

            Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
        }
    }
}
