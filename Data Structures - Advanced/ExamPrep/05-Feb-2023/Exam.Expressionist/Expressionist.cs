using System;
using System.Collections.Generic;

namespace Exam.Expressionist
{
    public class Expressionist : IExpressionist
    {
        private Dictionary<string, Expression> expressions;

        public Expressionist()
        {
            this.expressions = new Dictionary<string, Expression>();
        }

        public bool Contains(Expression expression)
            => this.expressions.ContainsKey(expression.Id);

        public int Count()
            => this.expressions.Count;

        public void AddExpression(Expression expression)
        {
            if (this.Contains(expression))
            {
                throw new ArgumentException();
            }

            this.expressions.Add(expression.Id, expression);
        }

        public void AddExpression(Expression expression, string parentId)
        {
            Expression parentExpression = this.GetExpression(parentId) ?? throw new ArgumentException();

            if (parentExpression.LeftChild == null)
            {
                parentExpression.LeftChild = expression;
            }
            else if (parentExpression.RightChild == null)
            {
                parentExpression.RightChild = expression;
            }
            else
            {
                throw new ArgumentException();
            }

            this.expressions.Add(expression.Id, expression);
        }

        public Expression GetExpression(string expressionId)
        {
            if (!this.expressions.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }

            return this.expressions[expressionId];
        }

        public void RemoveExpression(string expressionId)
        {
            if (!this.expressions.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }

            this.expressions.Remove(expressionId);
        }

        public string Evaluate()
        {
            if (this.expressions.Count == 0)
            {
                throw new ArgumentException();
            }

            Expression root = this.GetRootExpression();

            return root.Evaluate();
        }

        private Expression GetRootExpression()
        {
            foreach (var expression in this.expressions.Values)
            {
                if (expression.Root == null)
                {
                    return expression;
                }
            }

            throw new ArgumentException();
        }
    }
}
