namespace Exam.Expressionist
{
    public interface IExpressionist
    {
        void AddExpression(Expression expression);

        void AddExpression(Expression expression, string parentId);

        bool Contains(Expression expression);

        int Count();

        Expression GetExpression(string expressionId);

        void RemoveExpression(string expressionId);

        string Evaluate();
    }
}