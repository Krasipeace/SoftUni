using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.PackageManagerLite
{
    public class PackageManager : IPackageManager
    {
        private Dictionary<string, Package> packages;

        public PackageManager()
        {
            this.packages = new Dictionary<string, Package>();
        }
        public bool Contains(Package package)
            => this.packages.ContainsKey(package.Id);

        public int Count()
            => this.packages.Count;

        public void RegisterPackage(Package package)
        {
            var packageToRegister = this.packages.Values
                .FirstOrDefault(p => p.Name == package.Name && p.Version == package.Version);

            if (packageToRegister != null)
            {
                throw new ArgumentException();
            }

            packages.Add(package.Id, package);
        }

        public void AddDependency(string packageId, string dependencyId)
        {
            if (!this.packages.ContainsKey(packageId) || !this.packages.ContainsKey(dependencyId))
            {
                throw new ArgumentException();
            }

            var package = this.packages[packageId];
            var dependency = this.packages[dependencyId];

            package.Dependencies.Add(dependency);
            this.packages[packageId] = package;
        }

        public void RemovePackage(string packageId)
        {
            if (!this.packages.ContainsKey(packageId))
            {
                throw new ArgumentException();
            }

            var packageToRemove = this.packages[packageId];
            var dependants = this.GetDependants(packageToRemove);

            foreach (var dependant in dependants)
            {
                dependant.Dependencies.Remove(packageToRemove);
            }

            this.packages.Remove(packageId);
        }

        public IEnumerable<Package> GetDependants(Package package)
            => this.packages.Values
                .Where(p => p.Dependencies.Any(d => d.Id == package.Id))
                .ToList();

        public IEnumerable<Package> GetIndependentPackages()
            => this.packages.Values
                .Where(p => p.Dependencies.Count == 0)
                .OrderByDescending(p => p.ReleaseDate)
                .ThenBy(p => p.Version)
                .ToList();

        public IEnumerable<Package> GetOrderedPackagesByReleaseDateThenByVersion()
            => this.packages.Values
                .OrderByDescending(p => p.ReleaseDate)
                .ThenBy(p => p.Version)
                .ToList();
    }
}
