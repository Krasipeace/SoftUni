using System;

namespace Exam.PackageManagerLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var packageManager = new PackageManager();

            var package1 = new Package("1", "1", DateTime.Now, "1");
            var package2 = new Package("2", "2", DateTime.Now, "2");
            var package3 = new Package("3", "3", DateTime.Now, "1");
            var package4 = new Package("4", "4", DateTime.Now, "1");

            // Debugging time
            Console.WriteLine(packageManager.Count());
            packageManager.RegisterPackage(package4);
            packageManager.Contains(package4);
            packageManager.RemovePackage("4");
            Console.WriteLine(packageManager.Count());

            packageManager.RegisterPackage(package1);
            Console.WriteLine(packageManager.Count());

            packageManager.RegisterPackage(package2);
            Console.WriteLine(packageManager.Count());

            packageManager.RegisterPackage(package3);
            packageManager.AddDependency("1", "2");
            packageManager.AddDependency("1", "3");
            Console.WriteLine(packageManager.Count()); 
        }
    }
}
