using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (drone.Range > 15 || drone.Range < 5 || 
                drone.Name == null || drone.Name == string.Empty ||
                drone.Brand == null || drone.Brand == string.Empty ||
                Drones.Count > Capacity)
            {
                return "Invalid drone.";
            }

            if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var droneToRemove = Drones.Find(x => x.Name == name);

            return Drones.Remove(droneToRemove);
        }

        public int RemoveDroneByBrand(string brand)
        {
            return Drones.RemoveAll(x => x.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            var drone = Drones.Find(x => x.Name == name);
            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyingDrones = Drones.Where(x => x.Range >= range).ToList();
            foreach (var item in flyingDrones)
            {
                FlyDrone(item.Name);
            }

            return flyingDrones;
        }

        public string Report()
            => $"Drones available at {Name}:{Environment.NewLine}" +
               $"{string.Join(Environment.NewLine, Drones.Where(d => d.Available))}";
    }
}
