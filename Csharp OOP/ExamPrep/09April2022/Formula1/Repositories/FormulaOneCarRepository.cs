namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
            => models.AsReadOnly();

        public void Add(IFormulaOneCar model)
            => models.Add(model);

        public IFormulaOneCar FindByName(string name)
            => models.Find(x => x.Model == name);

        public bool Remove(IFormulaOneCar model)
            => models.Remove(model);
    }
}
