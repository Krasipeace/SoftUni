namespace MilitaryElite.Models
{
    using System;

    using Contracts;

    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }
        public int CodeNumber { get; }
        public override string ToString()
            => base.ToString() + Environment.NewLine + $"Code Number: {CodeNumber}";
    }
}
