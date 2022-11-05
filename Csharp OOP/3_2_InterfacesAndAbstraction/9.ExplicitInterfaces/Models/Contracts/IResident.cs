namespace ExplicitInterfaces.Models.Contracts
{
    public interface IResident
    {
        string Name { get; }
        int Age { get; }
        string GetName();
    }
}
