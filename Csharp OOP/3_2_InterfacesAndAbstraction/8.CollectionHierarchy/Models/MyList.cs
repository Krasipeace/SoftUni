namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Contracts;
    using Models;

    public class MyList<T> : IMyList<T>
    {
        private readonly IList<T> _collection;
        public MyList()
        {
            _collection = new List<T>();
        }

        public int Used => _collection.Count;
        public int Add (T item)
        {
            _collection.Add(item);

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
