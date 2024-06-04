namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IFish> Fish => fishes;

        public ICollection<IDecoration> Decorations => decorations;

        public int Comfort => decorations.Sum(x => x.Comfort);

        public void AddFish(IFish fish)
        {
            if (fishes.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            fishes.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (IFish item in fishes)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string fishesOrEmpty = fishes.Count != 0 ? string.Join(", ", fishes.Select(x => x.Name)) : "none";

            sb 
                .AppendLine($"{Name} ({GetType().Name}):")
                .AppendLine($"Fish: {fishesOrEmpty}")
                .AppendLine($"Decorations: {decorations.Count}")
                .AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
