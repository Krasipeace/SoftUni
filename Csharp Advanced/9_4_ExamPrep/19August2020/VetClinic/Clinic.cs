using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private Dictionary<string, Pet> Data;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            Data = new Dictionary<string, Pet>(capacity);
        }
        public int Capacity { get; set; }
        public int Count => Data.Count;

        public void Add(Pet pet)
        {
            string key = $"{pet.Name} {pet.Owner}";

            if (!Data.ContainsKey(key) && Count + 1 <= Capacity)
            {
                Data.Add(key, pet);
            }
        }

        public bool Remove(string name)
        {
            Pet removedPet = Data.Values.FirstOrDefault(x => x.Name == name);
            if (removedPet == null)
            {
                return false;
            }
            string petAndOwner = $"{removedPet.Name} {removedPet.Owner}";

            return Data.Remove(petAndOwner);
        }

        public Pet GetPet(string name, string owner)
        {
            string petAndOwner = $"{name} {owner}";

            if (Data.ContainsKey(petAndOwner))
            {
                return Data[petAndOwner];
            }
            else
            {
                return null;
            }          
        }

        public Pet GetOldestPet() => Data.Values.OrderByDescending(x => x.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("The clinic has the following patients:");

            foreach ((string _, Pet pet) in Data)
            {
                output.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
