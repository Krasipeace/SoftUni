using System.Collections.Generic;
using System.Linq;

using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models 
            => models;

        public void AddModel(IStudent model) 
            => models.Add(model);

        public IStudent FindById(int id) 
            => models.FirstOrDefault(m => m.Id == id);

        public IStudent FindByName(string name)
            => models.FirstOrDefault
                (m => m.FirstName == ((string[])name.Split(" "))[0] 
                    && m.LastName == ((string[])name.Split(" "))[1]);
    }
}