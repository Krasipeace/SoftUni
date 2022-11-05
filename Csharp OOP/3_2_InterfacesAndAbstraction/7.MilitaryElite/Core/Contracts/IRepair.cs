namespace MilitaryElite.Core.Contracts
{
    public interface IRepair
    {
        public string PartName { get; }
        public int RepairXHours { get; }
    }
}
