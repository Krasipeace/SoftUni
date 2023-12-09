using System.Collections.Generic;

namespace Exam.PackageManagerLite
{
    public interface IPackageManager
    {
        void RegisterPackage(Package package);

        void RemovePackage(string packageId);

        void AddDependency(string packageId, string dependencyId);

        bool Contains(Package package);

        int Count();

        IEnumerable<Package> GetDependants(Package package);

        IEnumerable<Package> GetIndependentPackages();

        IEnumerable<Package> GetOrderedPackagesByReleaseDateThenByVersion();
    }
}
