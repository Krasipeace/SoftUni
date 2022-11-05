namespace MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    using MilitaryElite.Core.Contracts;
    public interface IEngineer : ISpecialisedSoldier
    {
        public ICollection<IRepair> Repairs { get; }
    }
}
