using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(input.Reverse());
            
            while(stack.Count > 1)
            {
                int leftNumber = int.Parse(stack.Pop());
                char operatorr = char.Parse(stack.Pop());
                int rightNumber = int.Parse(stack.Pop());

                if (operatorr == '+')
                {
                    stack.Push((leftNumber + rightNumber).ToString());
                }
                else if (operatorr == '-')
                {
                    stack.Push((leftNumber - rightNumber).ToString());
                }
            }

            Console.WriteLine(stack.Pop());            
        }
    }
}
