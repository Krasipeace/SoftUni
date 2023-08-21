namespace Problem02.Stack
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Previous;

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

        public Node(T value, Node<T> next, Node<T> previous)
            : this(value, next)
        {
            this.Previous = previous;
        }
    }
}