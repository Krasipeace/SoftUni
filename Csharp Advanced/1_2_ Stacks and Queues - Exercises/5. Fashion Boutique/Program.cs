using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(inputs);
            
            int sum = 0;
            int boxCounter = 1;

            while (stack.Count > 0)
            {
                if (sum <= capacity)
                {
                    sum += stack.Peek();
                    if (sum > capacity)
                    {
                        sum = 0;
                        boxCounter++;

                        sum += stack.Peek();
                        stack.Pop();

                        continue;
                    }

                    stack.Pop();
                }
                else 
                {
                    if (stack.Count != 0)
                    {
                        sum = 0;
                        capacity++;

                        sum += stack.Peek();
                        stack.Pop();
                    }

                }
            }
            Console.WriteLine(boxCounter);


        }
    }
}
