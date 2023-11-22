namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int InitialCapacity = 4;
        private const float LoadFactor = 0.75f;
        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public int Count { get; private set; }

        public int Capacity => this.slots.Length;

        public HashTable() : this(InitialCapacity)
        {
        }

        public HashTable(int capacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        private HashTable(int capacity, IEnumerable<KeyValue<TKey, TValue>> keyValuePairs)
            : this(capacity)
        {
            foreach (var element in keyValuePairs)
            {
                this.Add(element.Key, element.Value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            this.GrowIfNeeded();

            int index = Math.Abs(key.GetHashCode()) % this.Capacity;

            if (this.slots[index] == null)
            {
                this.slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var element in this.slots[index])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException("Duplicate Key", key.ToString());
                }
            }

            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[index].AddLast(newElement);
            this.Count++;
        }

        private void GrowIfNeeded()
        {
            // float, because i don't need integer division
            if ((float)(this.Count + 1) / this.Capacity >= LoadFactor)
            {
                var newTable = new HashTable<TKey, TValue>(this.Capacity * 2, this);

                this.slots = newTable.slots;
            }
        }

        public TValue Get(TKey key)
            => this.Find(key) == null
                ? throw new KeyNotFoundException()
                : this.Find(key).Value;

        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            try
            {
                this.Add(key, value);
            }
            catch (ArgumentException argumentException)
            {
                if (argumentException.Message.Contains("Duplicate Key")
                    && argumentException.ParamName == key.ToString())
                {
                    int index = Math.Abs(key.GetHashCode()) % this.Capacity;

                    KeyValue<TKey, TValue> keyValue = this.slots[index]
                        .FirstOrDefault(kvp => kvp.Key.Equals(key));
                    keyValue.Value = value;

                    return true;
                }

                throw argumentException;
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            KeyValue<TKey, TValue> element = this.Find(key);

            if (element != null)
            {
                value = element.Value;

                return true;
            }

            value = default;

            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int index = Math.Abs(key.GetHashCode()) % this.Capacity;

            if (this.slots[index] != null)
            {
                foreach (var kvp in this.slots[index])
                {
                    if (kvp.Key.Equals(key))
                    {
                        return kvp;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
            => this.Find(key) != null;

        public bool Remove(TKey key)
        {
            int index = Math.Abs(key.GetHashCode()) % this.Capacity;

            if (this.slots[index] != null)
            {
                LinkedListNode<KeyValue<TKey, TValue>> node = this.slots[index].First;

                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        this.slots[index].Remove(node);
                        this.Count--;

                        return true;
                    }

                    node = node.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys
            => this.Select(e => e.Key);

        public IEnumerable<TValue> Values
        {
            get
            {
                var result = new List<TValue>();
                foreach (var slot in this.slots)
                {
                    if (slot != null)
                    {
                        foreach (var element in slot)
                        {
                            result.Add(element.Value);
                        }
                    }
                }

                return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var slot in this.slots)
            {
                if (slot != null)
                {
                    foreach (var element in slot)
                    {
                        yield return element;
                    }
                }
            }
        }
    }
}