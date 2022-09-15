using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < inputs; i++)
            {
                int[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int action = command[0];

                switch (action)
                {
                    case 1:
                        stack.Push(command[1]);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        { 
                            stack.Pop();
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case 4: 
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        else
                        {
                            continue;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
