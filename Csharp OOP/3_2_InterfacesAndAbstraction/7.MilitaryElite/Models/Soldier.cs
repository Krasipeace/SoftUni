namespace MilitaryElite.Models
{
    using Contracts;
    public class Soldier : ISoldier
    {
        public Soldier(int id, string name, string lastName)
        {
            Id = id;
            FirstName = name;
            LastName = lastName;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
            => $"Name: {FirstName} {LastName} Id: {Id}";
    }
}
