namespace Problem03.Queue
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Prev;

        public Node()
        {
        }

        public Node(T value)
        {
            this.Value = value;
        }

        public Node(T value, Node<T> next)
            : this(value)
        {
            this.Next = next;
        }

        public Node(T value, Node<T> next, Node<T> prev)
            : this(value, next)
        {
            this.Prev = prev;
        }
    }
}