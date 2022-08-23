using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int leftNumber = int.Parse(stack.Pop());
                char operatorr = char.Parse(stack.Pop());
                int rightNumber = int.Parse(stack.Pop());

                switch (operatorr)
                {
                    case '+':
                        stack.Push((leftNumber + rightNumber).ToString());
                        break;
                    case '-':
                        stack.Push((leftNumber - rightNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}