namespace MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    using MilitaryElite.Core.Contracts;
    public interface ICommando : ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get; }
    }
}
