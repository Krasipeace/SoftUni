using System;
using System.Collections.Generic;

namespace _13._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();
            bool isBracketsBalanced = true;

            foreach (var currBracket in input)
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
                Console.WriteLine("NO");                               
            }
            else
            {
                Console.WriteLine("YES"); 
            }
        }
    }
}
