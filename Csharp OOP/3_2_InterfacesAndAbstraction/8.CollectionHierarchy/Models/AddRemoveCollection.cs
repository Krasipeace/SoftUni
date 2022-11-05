namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using CollectionHierarchy.Models.Contracts;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> _collection;

        public AddRemoveCollection()
        {
            _collection = new List<T>();
        }

        public int Add(T item)
        {
            _collection.Insert(0, item);

            return 0;
        }
        public T Remove()
        {
            T itemToRemove = _collection.LastOrDefault();
            if (itemToRemove != null)
            {
                _collection.Remove(itemToRemove);
            }

            return itemToRemove;
        }
    }
}
