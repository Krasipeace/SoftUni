namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;
        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => races.AsReadOnly();

        public void Add(IRace model)
            => races.Add(model);

        public IRace FindByName(string name)
            => races.Find(x => x.RaceName == name);

        public bool Remove(IRace model)
            => races.Remove(model);
    }
}
