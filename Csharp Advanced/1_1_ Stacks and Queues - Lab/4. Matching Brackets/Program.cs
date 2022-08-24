using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i);
                }
                if (input[i] == ')')
                {
                    int firstBracket = brackets.Pop();
                    int lastBracket = i;
                    Console.WriteLine(input.Substring(firstBracket, lastBracket - firstBracket + 1));
                }
            }
        }
    }
}
