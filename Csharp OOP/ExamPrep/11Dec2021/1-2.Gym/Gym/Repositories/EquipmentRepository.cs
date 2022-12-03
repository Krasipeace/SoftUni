namespace Gym.Repositories
{
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;

    using System.Collections.Generic;
    using System.Linq;
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> equipments;
        public EquipmentRepository()
        {
            equipments = new HashSet<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => (IReadOnlyCollection<IEquipment>)equipments;

        public void Add(IEquipment model)
        {
            equipments.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return equipments.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return equipments.Remove(model);
        }
    }
}
