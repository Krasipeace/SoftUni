using System;
using System.Collections.Generic;
using System.Linq;

namespace TripAdministrations
{
    public class TripAdministrator : ITripAdministrator
    {
        private readonly Dictionary<string, Company> companies = new Dictionary<string, Company>();
        private readonly Dictionary<string, Trip> trips = new Dictionary<string, Trip>();
        private readonly Dictionary<Company, List<Trip>> companyWithTrips = new Dictionary<Company, List<Trip>>();

        public void AddCompany(Company c)
        {
            if (this.Exist(c))
            {
                throw new ArgumentException();
            }
            
            this.companies.Add(c.Name, c);
            this.companyWithTrips.Add(c, new List<Trip>());
        }

        public void AddTrip(Company c, Trip t)
        {
            if (!this.Exist(c))
            {
                throw new ArgumentException();
            }

            this.trips.Add(t.Id, t);
            this.companyWithTrips[c].Add(t);
        }

        public bool Exist(Company c)
            => this.companies.ContainsKey(c.Name);

        public bool Exist(Trip t)
            => this.trips.ContainsKey(t.Id);

        public void RemoveCompany(Company c)
        {
            if (!this.Exist(c))
            {
                throw new ArgumentException();
            }

            var trips = this.companyWithTrips[c];
            foreach (var trip in trips)
            {
                this.trips.Remove(trip.Id);
            }

            this.companyWithTrips.Remove(c);
            this.companies.Remove(c.Name);
        }

        public IEnumerable<Company> GetCompanies()
            => this.companies.Values;

        public IEnumerable<Trip> GetTrips()
            => this.trips.Values;

        public void ExecuteTrip(Company c, Trip t)
        {
            if (!this.Exist(c) 
                || !this.Exist(t)
                || !this.companyWithTrips[c].Contains(t))
            {
                throw new ArgumentException();
            }
            
            this.trips.Remove(t.Id);
            this.companyWithTrips[c].Remove(t);
        }

        public IEnumerable<Company> GetCompaniesWithMoreThatNTrips(int n)
            => this.companyWithTrips
            .Where(c => c.Value.Count > n)
            .Select(c => c.Key);
            
        public IEnumerable<Trip> GetTripsWithTransportationType(Transportation t)
            => this.trips.Values
                .Where(trip => trip.Transportation == t);

        public IEnumerable<Trip> GetAllTripsInPriceRange(int lo, int hi)
            => this.trips.Values
                .Where(t => t.Price >= lo && t.Price <= hi);
    }
}
