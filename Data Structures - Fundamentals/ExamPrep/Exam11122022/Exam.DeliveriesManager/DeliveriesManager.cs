using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<Package, Deliverer> packages;
        private Dictionary<Deliverer, List<Package>> deliverers;

        public DeliveriesManager()
        {
            this.deliverers = new Dictionary<Deliverer, List<Package>>();
            this.packages = new Dictionary<Package, Deliverer>();
        }

        public void AddDeliverer(Deliverer deliverer)
        {
            if (!Contains(deliverer))
            {
                this.deliverers.Add(deliverer, new List<Package>());
            }
        }

        public void AddPackage(Package package)
        {
            if (!Contains(package))
            {
                this.packages.Add(package, null);
            }
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!Contains(deliverer) || !Contains(package))
            {
                throw new ArgumentException();
            }

            this.packages[package] = deliverer;

            if (!this.deliverers.ContainsKey(deliverer))
            {
                this.deliverers[deliverer] = new List<Package>() 
                { 
                    package 
                };
            }
            else
            {
                this.deliverers[deliverer].Add(package);
            }
        }

        public bool Contains(Deliverer deliverer)
            => this.deliverers.ContainsKey(deliverer);

        public bool Contains(Package package)
            => this.packages.ContainsKey(package);

        public IEnumerable<Deliverer> GetDeliverers()
        {
            if (this.deliverers.Count == 0)
            {
                return new List<Deliverer>();
            }

            return this.deliverers.Keys;
        }
        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
            => this.deliverers.Keys
                .OrderByDescending(d => this.deliverers[d]?.Count ?? 0)
                .ThenBy(d => d.Name);      

        public IEnumerable<Package> GetPackages()
            => this.packages.Keys;

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
            => this.packages.Keys
                .OrderByDescending(p => p.Weight)
                .ThenBy(p => p.Receiver, StringComparer.OrdinalIgnoreCase)
                .ToList();       

        public IEnumerable<Package> GetUnassignedPackages()
            => this.packages
                .Where(p => p.Value == null)
                .Select(p => p.Key);        
    }
}
