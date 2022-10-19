using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }
        private List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (Participants.Count < Capacity && Participants.All(c => c.LicensePlate != car.LicensePlate && car.HorsePower <= MaxHorsePower))
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
            => Participants.Remove(Participants.Find(c => c.LicensePlate == licensePlate));

        public Car FindParticipant(string licensePlate)
        {
            foreach (Car thisCar in Participants.Where(c => c.LicensePlate == licensePlate))
            {
                return thisCar;
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count > 0)
            {
                return Participants.OrderByDescending(c => c.HorsePower).First();
            }

            return null;
        }

        public string Report()
            => $"Race: {Name} - Type: {Type} (Laps: {Laps})" +
               Environment.NewLine +
               string.Join(Environment.NewLine, Participants);
    }
}
