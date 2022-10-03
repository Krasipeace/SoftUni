using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);
                if (!cars.Contains(car))
                {
                    cars.Add(car);
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = tokens[1];
                double amountKm = double.Parse(tokens[2]);

                Car carToDrive = cars.First(c => c.Model == carModel);
                carToDrive.Drive(amountKm);

                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
