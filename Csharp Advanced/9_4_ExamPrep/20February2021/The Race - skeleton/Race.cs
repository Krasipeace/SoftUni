using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;
        public Race(string name, int capacity)
        {
            racers = new List<Racer>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return racers.Count; } }

        public void Add(Racer racer)
        {
            if (racers.Count < Capacity)
            {
                racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            return racers.Remove(racers.FirstOrDefault(r => r.Name == name));
        }

        public Racer GetRacer(string name)
        {
            Racer getRacer = racers.FirstOrDefault(r => r.Name == name);

            return getRacer;
        }
        public Racer GetOldestRacer()
        {
            Racer oldestRacer = racers.OrderByDescending(r => r.Age).FirstOrDefault();

            return oldestRacer;
        }
        public Racer GetFastestRacer()
        {
            Racer fastestRacer = racers.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

            return fastestRacer;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racer participating at {Name}:");
            foreach (var item in racers)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
