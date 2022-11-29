namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models 
            => models.AsReadOnly();

        public void Add(IPilot model)
            => models.Add(model);

        public IPilot FindByName(string name)
            => models.Find(x => x.FullName == name);

        public bool Remove(IPilot model)
            => models.Remove(model);
    }
}
