using System;
using System.Collections.Generic;

using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    internal class BoothRepository : IRepository<IBooth>
    {
        private readonly List<IBooth> models;

        public BoothRepository()
        {
            models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => models.AsReadOnly();

        public void AddModel(IBooth model)
        {
            models.Add(model);
        }
    }
}
