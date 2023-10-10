using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportManagementSystem
{
    public class PublicTransportRepository : IPublicTransportRepository
    {
        private readonly Dictionary<string, Passenger> passengers = new Dictionary<string, Passenger>();
        private readonly Dictionary<string, Bus> buses = new Dictionary<string, Bus>();

        public void RegisterPassenger(Passenger passenger)
            => this.passengers.Add(passenger.Id, passenger);

        public void AddBus(Bus bus)
            => this.buses.Add(bus.Id, bus);

        public bool Contains(Passenger passenger)
            => this.passengers.ContainsKey(passenger.Id);

        public bool Contains(Bus bus)
            => this.buses.ContainsKey(bus.Id);

        public IEnumerable<Bus> GetBuses()
            => this.buses.Values;

        public void BoardBus(Passenger passenger, Bus bus)
        {
            ValidatePassengerAndBus(passenger, bus);

            bus.Passengers.Add(passenger);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            ValidatePassengerAndBus(passenger, bus);

            if (!bus.Passengers.Contains(passenger))
            {
                throw new InvalidOperationException();
            }

            bus.Passengers.Remove(passenger);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
            => this.buses[bus.Id].Passengers;

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
            => this.buses.Values
                .OrderBy(b => b.Capacity);

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
            => this.buses.Values
                .Where(b => b.Capacity >= capacity);


        private void ValidatePassengerAndBus(Passenger passenger, Bus bus)
        {
            if (!this.Contains(passenger) || !this.Contains(bus))
            {
                throw new ArgumentException();
            }
        }
    }
}