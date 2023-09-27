namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VaccDb : IVaccOps
    {
        private readonly Dictionary<string, Doctor> doctors;
        private readonly Dictionary<string, Patient> patients;

        public VaccDb()
        {
            this.doctors = new Dictionary<string, Doctor>();
            this.patients = new Dictionary<string, Patient>();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (this.Exist(doctor))
            {
                throw new ArgumentException();
            }

            this.doctors.Add(doctor.Name, doctor);
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!this.Exist(doctor))
            {
                throw new ArgumentException();
            }

            this.patients.Add(patient.Name, patient);
            this.doctors[doctor.Name].Patients.Add(patient);
            patient.Doctor = doctor;
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!this.Exist(oldDoctor) 
                || !this.Exist(newDoctor) 
                || !this.Exist(patient))
            {
                throw new ArgumentException();
            }

            oldDoctor.Patients.Remove(patient);
            newDoctor.Patients.Add(patient);
            patient.Doctor = newDoctor;
        }

        public bool Exist(Doctor doctor)
            => this.doctors.ContainsKey(doctor.Name);

        public bool Exist(Patient patient)
            => this.patients.ContainsKey(patient.Name);

        public IEnumerable<Doctor> GetDoctors()
            => this.doctors.Values;

        public IEnumerable<Patient> GetPatients()
            => this.patients.Values;

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
            => GetDoctors()
                .Where(d => d.Popularity == populariry);

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
            => GetDoctors()
                .OrderByDescending(d => d.Patients.Count)
                .ThenBy(d => d.Name);

        public IEnumerable<Patient> GetPatientsByTown(string town)
            => GetPatients()
                .Where(p => p.Town == town);

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
            => GetPatients()
                .Where(p => p.Age >= lo && p.Age <= hi);

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
            => GetPatients()
                .OrderBy(p => p.Doctor.Popularity)
                .ThenByDescending(p => p.Height)
                .ThenBy(p => p.Age);

        public Doctor RemoveDoctor(string name)
        {
            if (!this.doctors.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            var doctor = this.doctors[name];

            this.doctors.Remove(name);

            foreach (var patient in doctor.Patients)
            {
                this.patients.Remove(patient.Name);
            }

            return doctor;
        }
    }
}
