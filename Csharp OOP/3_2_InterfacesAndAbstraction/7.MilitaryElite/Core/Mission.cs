namespace MilitaryElite.Core
{
    using Contracts;
    using MilitaryElite.Models.Enums;

    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName { get; }
        public State State { get; private set; }
        public void CompleteMission()
        {
            State = State.Finished;
        }
        public override string ToString()      
            => $"Code Name: {CodeName} State: {State}";        
    }
}
