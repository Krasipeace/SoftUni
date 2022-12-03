namespace Gym.Repositories
{
    using System.Collections.Generic;
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipment;
        public EquipmentRepository()
        {
            equipment = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => equipment.AsReadOnly();

        public void Add(IEquipment model)
        {
            this.equipment.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return equipment.Find(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return equipment.Remove(model);
        }
    }
}
