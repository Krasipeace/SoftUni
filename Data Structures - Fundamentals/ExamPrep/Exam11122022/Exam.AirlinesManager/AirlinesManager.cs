using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private Dictionary<Flight, Airline> flights;
        private Dictionary<Airline, List<Flight>> airlines;

        public AirlinesManager()
        {
            this.flights = new Dictionary<Flight, Airline>();
            this.airlines = new Dictionary<Airline, List<Flight>>();
        }

        public void AddAirline(Airline airline)
        {
            if (!Contains(airline))
            {
                this.airlines.Add(airline, new List<Flight>());
            }
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!Contains(airline))
            {
                throw new ArgumentException();
            }

            this.flights.Add(flight, airline);
        }

        public bool Contains(Airline airline)
            => this.airlines.ContainsKey(airline);

        public bool Contains(Flight flight)
            => this.flights.ContainsKey(flight);

        public void DeleteAirline(Airline airline)
        {
            if (!Contains(airline))
            {
                throw new ArgumentException();
            }

            var removeFlights = this.airlines[airline];
            foreach (var flight in removeFlights)
            {
                this.flights.Remove(flight);
            }

            this.airlines.Remove(airline);
        }
        public IEnumerable<Flight> GetAllFlights()
        {
            if (this.flights.Count == 0)
            {
                return new List<Flight>();
            }

            return this.flights.Keys;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            if (this.flights.Count == 0)
            {
                return new List<Flight>();
            }

            return this.flights.Keys
                .Where(f => f.IsCompleted);
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!Contains(airline) || !Contains(flight))
            {
                throw new ArgumentException();
            }

            flight.IsCompleted = true;

            return flight;
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
            => this.airlines
                .OrderByDescending(a => a.Key.Rating)
                .ThenBy(a => a.Value.Count)
                .ThenBy(a => a.Key.Name)
                .Select(a => a.Key);

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
            => this.airlines
                .Where(a => a.Value.Any(f => f.Origin == origin && f.Destination == destination))
                .Select(a => a.Key);

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
            => this.flights
                .OrderBy(f => f.Key.IsCompleted)
                .ThenBy(f => f.Key.Number)
                .Select(f => f.Key);
    }
}
