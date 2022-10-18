using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Ski> data { get; set; } = new List<Ski>();
        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
            if (skiToRemove != null)
            {
                data.Remove(skiToRemove);

                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            Ski ski = data.OrderByDescending(x => x.Year).First();

            return ski;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            if (manufacturer != null && model != null)
            {
                return data.FindAll(data => data.Manufacturer == manufacturer && data.Model == model).FirstOrDefault();
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
