namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrEmpty(parentheses) || parentheses.Length % 2 != 0)
            {
                return false;
            }

            Stack<char> brackets = new Stack<char>();
            bool isBracketsBalanced = true;

            foreach (var currBracket in parentheses)
            {
                if (currBracket == '{' || currBracket == '[' || currBracket == '(')
                {
                    brackets.Push(currBracket);
                    continue;
                }

                if (brackets.Count == 0)
                {
                    isBracketsBalanced = false;
                    break;
                }

                if (currBracket == ')' && brackets.Peek() == '(')
                {
                    brackets.Pop();
                }
                else if (currBracket == '}' && brackets.Peek() == '{')
                {
                    brackets.Pop();
                }
                else if (currBracket == ']' && brackets.Peek() == '[')
                {
                    brackets.Pop();
                }
                else
                {
                    isBracketsBalanced = false;
                    break;
                }
            }

            if (!isBracketsBalanced || brackets.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
