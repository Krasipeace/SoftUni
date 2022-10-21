using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get; set; }
        public int Count => Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            const int MONEY_LIMIT = 350;
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return $"Invalid renovator's information.";
            }
            if (Count == NeededRenovators)
            {
                return $"Renovators are no more needed.";
            }
            if (renovator.Rate > MONEY_LIMIT)
            {
                return $"Invalid renovators's rate.";
            }
            Renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
            => Renovators.Remove(Renovators.Find(x => x.Name == name));

        public int RemoveRenovatorBySpecialty(string type)
            => Renovators.RemoveAll(x => x.Type == type);

        public Renovator HireRenovator(string name)
        {
            var toHire = Renovators.Find(x => x.Name == name);
            if (toHire != null)
            {
                toHire.Hired = true;
            }

            return toHire;
        }

        public List<Renovator> PayRenovators(int days)
           => Renovators.Where(x => x.Days >= days).ToList();

        public string Report()
        {
            return $"Renovators available for Project {Project}:" + Environment.NewLine +
                   string.Join(Environment.NewLine, Renovators.FindAll(x => !x.Hired));
        }
    }
}
