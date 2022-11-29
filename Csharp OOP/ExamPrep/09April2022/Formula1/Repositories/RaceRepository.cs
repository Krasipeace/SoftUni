namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();

        public void Add(IRace model)
            => models.Add(model);

        public IRace FindByName(string name)
            => models.Find(x => x.RaceName == name);

        public bool Remove(IRace model)
            => models.Remove(model);
    }
}
