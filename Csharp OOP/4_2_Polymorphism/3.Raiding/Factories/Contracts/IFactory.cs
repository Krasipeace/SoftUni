namespace Raiding.Factories.Contracts
{
    using Raiding.Models;

    public interface IFactory
    {
        BaseHero CreateHero(string type, string name);
    }
}
