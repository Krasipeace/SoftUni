namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars;
        public FormulaOneCarRepository() 
            => cars = new List<IFormulaOneCar>(); 

        public IReadOnlyCollection<IFormulaOneCar> Models 
            => cars.AsReadOnly();

        public void Add(IFormulaOneCar model) 
            => cars.Add(model);

        public IFormulaOneCar FindByName (string name)
            => cars.Find(x => x.Model == name);

        public bool Remove(IFormulaOneCar model)
            => cars.Remove(model);
    }
}
