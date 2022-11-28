﻿namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots;
        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models 
            => pilots.AsReadOnly();

        public void Add(IPilot model)
            => pilots.Add(model);

        public IPilot FindByName(string name)
            => pilots.Find(x => x.FullName == name);

        public bool Remove(IPilot model)
            => pilots.Remove(model);
    }
}
