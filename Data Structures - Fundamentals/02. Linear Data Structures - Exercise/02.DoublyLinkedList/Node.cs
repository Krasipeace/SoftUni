namespace Problem02.DoublyLinkedList
{
    public partial class DoublyLinkedList<T>
    {
        private class Node
        {
            public Node Next { get; set; }

            public Node Previous { get; set; }

            public T Value { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }
    }
}
