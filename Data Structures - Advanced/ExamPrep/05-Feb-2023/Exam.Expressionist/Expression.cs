namespace Exam.Expressionist
{
    public class Expression
    {
        public Expression(string id, string value, ExpressionType type, Expression leftChild, Expression rightChild)
        {
            Id = id;
            Value = value;
            Type = type;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public Expression()
        {
        }

        public string Id { get; set; }
        public string Value { get; set; }
        public ExpressionType Type { get; set; }
        public Expression LeftChild { get; set; }
        public Expression RightChild { get; set; }
        public Expression Root { get; set; }

        public string Evaluate()
        {
            if (this.LeftChild == null && this.RightChild == null)
            {
                return this.Value.ToString();
            }
            else
            {
                string leftResult = this.LeftChild.Evaluate();
                string rightResult = this.RightChild.Evaluate();

                return $"({leftResult} {this.Value} {rightResult})";
            }
        }
    }
}
