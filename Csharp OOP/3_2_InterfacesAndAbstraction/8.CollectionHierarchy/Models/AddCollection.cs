namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using CollectionHierarchy.Models.Contracts;
    using Models;

    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly ICollection<T> _collection;

        public AddCollection()
        {
            _collection = new List<T>();
        }

        public int Add(T item)
        {
            _collection.Add(item);

            return _collection.Count - 1;
        }
    }
}
