using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }
        private readonly List<Fish> fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => fish.Count;
        public List<Fish> Fish => fish;
        public string AddFish(Fish fish)
        {
            if (fish.FishType == string.Empty || fish.Length <= 0 || fish.Weight <= 0 || string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }
            if (Fish.Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }
            this.fish.Add(fish);

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish thisFish = fish.FirstOrDefault(x => x.Weight == weight);
            if (thisFish != null)
            {
                return fish.Remove(thisFish);
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish thisFish = fish.FirstOrDefault(x => x.FishType == fishType);

            return thisFish;
        }

        public Fish GetBiggestFish()
        {
            double bigFish = fish.Max(x => x.Length);
            Fish thisFish = fish.FirstOrDefault(x => x.Length == bigFish);

            return thisFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var item in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
