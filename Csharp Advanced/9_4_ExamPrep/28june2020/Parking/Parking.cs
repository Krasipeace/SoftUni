using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return cars.Count; } }

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (car != null)
            {
                cars.Remove(car);

                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            return cars.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder stats = new StringBuilder();
            stats.AppendLine($"The cars are parked in {Type}:");

            foreach (Car car in cars)
            {
                stats.AppendLine(car.ToString());
            }

            return stats.ToString();
        }
    }
}
