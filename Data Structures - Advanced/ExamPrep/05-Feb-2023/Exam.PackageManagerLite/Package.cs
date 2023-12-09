using System;
using System.Collections.Generic;

namespace Exam.PackageManagerLite
{
    public class Package
    {
        public Package(string id, string name, DateTime releaseDate, string version)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            Version = version;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Version { get; set; }

        public HashSet<Package> Dependencies { get; set; } = new HashSet<Package>();
    }
}
