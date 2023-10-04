using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberShop
{
    public class BarberShop : IBarberShop
    {
        private readonly Dictionary<string, Barber> barbers = new Dictionary<string, Barber>();
        private readonly Dictionary<string, Client> clients = new Dictionary<string, Client>();
        private readonly Dictionary<string, List<string>> barberWithClients = new Dictionary<string, List<string>>();

        public void AddBarber(Barber b)
        {
            if (this.Exist(b))
            {
                throw new ArgumentException("Barber already exists");
            }

            this.barbers.Add(b.Name, b);
            this.barberWithClients.Add(b.Name, new List<string>());
        }

        public void AddClient(Client c)
        {
            if (this.Exist(c))
            {
                throw new ArgumentException("Client already exists");
            }

            this.clients.Add(c.Name, c);
        }

        public bool Exist(Barber b)
            => this.barbers.ContainsKey(b.Name);

        public bool Exist(Client c)
            => this.clients.ContainsKey(c.Name);

        public IEnumerable<Barber> GetBarbers()
            => this.barbers.Values.ToArray();

        public IEnumerable<Client> GetClients()
            => this.clients.Values.ToArray();

        public void AssignClient(Barber b, Client c)
        {
            if (!this.Exist(b) || !this.Exist(c))
            {
                throw new ArgumentException();
            }

            c.Barber = b;
            this.barberWithClients[b.Name].Add(c.Name);
        }

        public void DeleteAllClientsFrom(Barber b)
        {
            if (!this.Exist(b))
            {
                throw new ArgumentException();
            }

            foreach (var client in clients.Where(c => c.Value.Barber.Name == b.Name))
            {
                this.clients.Remove(client.Key);
            }
        }

        public IEnumerable<Client> GetClientsWithNoBarber()
            => this.clients.Values
            .Where(c => c.Barber == null)
            .ToArray();

        public IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc()       
            => this.barberWithClients
                .OrderByDescending(b => b.Value.Count)
                .Select(b => this.barbers[b.Key]);

        public IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc()
            => this.barbers.Values
                .OrderByDescending(b => b.Stars)
                .ThenBy(b => b.HaircutPrice);

        public IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc()
            => this.clients.Values
                .OrderByDescending(c => c.Age)
                .ThenByDescending(c => c.Barber.Stars);
    }
}
