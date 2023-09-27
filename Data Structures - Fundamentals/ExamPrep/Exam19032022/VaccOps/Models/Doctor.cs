namespace VaccOps.Models
{
    using System.Collections.Generic;

    public class Doctor
    {
        public Doctor(string name, int popularity)
        {
            this.Name = name;
            this.Popularity = popularity;
            this.Patients = new List<Patient>();
        }

        public string Name { get; set; }
        public int Popularity { get; set; }

        public List<Patient> Patients { get; set; }
    }
}
