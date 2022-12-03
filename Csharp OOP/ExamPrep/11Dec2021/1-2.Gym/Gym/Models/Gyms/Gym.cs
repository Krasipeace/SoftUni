using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private double equipmentWeight;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        protected Gym()
        {
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public Gym(string name, int capacity) : this()
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                capacity = value;
            }
        }

        public double EquipmentWeight
            => Equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete item in Athletes)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            string output = Athletes.Any() ? string.Join(", ", Athletes.Select(x => x.FullName)) : "No athletes";

            sb
                .AppendLine($"{Name} is a {GetType().Name}:")
                .AppendLine($"Athletes: {output}")
                .AppendLine($"Equipment total count: {Equipment.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
