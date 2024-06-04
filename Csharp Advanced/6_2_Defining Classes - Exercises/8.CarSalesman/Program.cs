using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            GetEngines(engines);

            GetCars(cars, engines);

            PrintCars(cars);
        }

        static void GetEngines(List<Engine> engines)
        {
            int inputEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputEngines; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);

                string displacement, efficiency;
                GetOptions(input, out displacement, out efficiency);

                Engine engine = new Engine(model, power, displacement, efficiency);

                if (!engines.Contains(engine))
                {
                    engines.Add(engine);
                }
            }
        }
        static void GetCars(List<Car> cars, List<Engine> engines)
        {
            int inputCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string currEngine = input[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == currEngine);

                string weight, color;
                GetOptions(input, out weight, out color);

                Car currCar = new Car(model, engine, weight, color);
                if (!cars.Contains(currCar))
                {
                    cars.Add(currCar);
                }
            }
        }

        static void GetOptions(string[] input, out string OptionOne, out string OptionTwo)
        {
            OptionOne = "n/a";
            OptionTwo = "n/a";
            switch (input.Length)
            {
                case 3:
                    {
                        int option;
                        bool isNumber = int.TryParse(input[2], out option);
                        if (isNumber)
                        {
                            OptionOne = input[2];
                        }
                        else
                        {
                            OptionOne = "n/a";
                            OptionTwo = input[2];
                        }
                        break;
                    }
                case 4:
                    OptionOne = input[2];
                    OptionTwo = input[3];
                    break;
            }
        }
        static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Car.PrintCar(car);
            }
        }
    }
}
