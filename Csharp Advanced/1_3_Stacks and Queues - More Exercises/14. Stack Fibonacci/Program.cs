using System;
using System.Collections.Generic;

namespace _14._Stack_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int index = int.Parse(Console.ReadLine());

            Stack<ulong> fibonacci = new Stack<ulong>();

            fibonacci.Push(1);
            fibonacci.Push(1);

            for (int i = 0; i < index - 1; i++)
            {
                if (fibonacci.Count == index)
                {
                    break;
                }

                ulong fibFirst = fibonacci.Pop();
                ulong fibSecond = fibonacci.Peek();

                fibonacci.Push(fibFirst);
                fibonacci.Push(fibFirst + fibSecond);
            }
            Console.WriteLine(fibonacci.Pop());
        }
    }
}
