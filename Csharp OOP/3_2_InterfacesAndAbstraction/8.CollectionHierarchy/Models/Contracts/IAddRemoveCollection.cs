namespace CollectionHierarchy.Models.Contracts
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
