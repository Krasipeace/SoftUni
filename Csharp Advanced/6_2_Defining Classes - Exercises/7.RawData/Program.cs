using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(
                    carData[0],                                                 //Model
                    int.Parse(carData[1]), int.Parse(carData[2]),               //Engine
                    int.Parse(carData[3]), carData[4],                          //Cargo
                    double.Parse(carData[5]), int.Parse(carData[6]),            //Tires
                    double.Parse(carData[7]), int.Parse(carData[8]),
                    double.Parse(carData[9]), int.Parse(carData[10]),
                    double.Parse(carData[11]), int.Parse(carData[12])
                    );

                cars.Add(car);
            }

            List<string> filter = GetStatusOfCar(cars);

            PrintFilteredCar(filter);
        }       

        static List<string> GetStatusOfCar(List<Car> cars)
        {
            List<string> filter = new List<string>();
            string status = Console.ReadLine();
            switch (status)
            {
                case "fragile":
                    {
                        filter = cars
                            .Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                            .Select(c => c.Model)
                            .ToList();
                        break;
                    }

                case "flammable":
                    {
                        filter = cars
                            .Where(c => c.Cargo.CargoType == "flammable" && c.Engine.Power > 250)
                            .Select(c => c.Model)
                            .ToList();
                        break;
                    }
            }

            return filter;
        }
        static void PrintFilteredCar(List<string> filter)
        {
            foreach (var item in filter)
            {
                Console.WriteLine($"{string.Join(" ", item)}");
            }
        }
    }
}
