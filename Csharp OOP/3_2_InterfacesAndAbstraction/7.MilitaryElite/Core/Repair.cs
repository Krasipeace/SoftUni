namespace MilitaryElite.Core
{
    using Contracts;

    public class Repair : IRepair
    {
        public Repair(string partName, int repairXHours)
        {
            PartName = partName;
            RepairXHours = repairXHours;
        }
        public string PartName { get; }
        public int RepairXHours { get; }
        public override string ToString()
            => $"Part Name: {PartName} Hours Worked: {RepairXHours}";
    }
}
