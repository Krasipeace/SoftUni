namespace MilitaryElite.Core.Contracts
{
    using MilitaryElite.Models.Enums;

    public interface IMission
    {
        public string CodeName { get; }
        public State State { get; }
        public void CompleteMission();
    }
}
