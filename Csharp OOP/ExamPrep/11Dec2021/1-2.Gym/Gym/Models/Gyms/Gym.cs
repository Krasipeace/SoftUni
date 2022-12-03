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
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
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
            => equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete item in athletes)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            string output = athletes.Any() ? string.Join(", ", athletes.Select(x => x.FullName)) : "No athletes";

            sb
                .AppendLine($"{Name} is a {GetType().Name}:")
                .AppendLine($"Athletes: {output}")
                .AppendLine($"Equipment total count: {this.equipment.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
