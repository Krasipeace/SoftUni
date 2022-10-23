using System;
using System.Linq;

namespace _2.ImplementingCustomStackClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack customStack = new CustomStack();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);            

            Console.WriteLine(customStack.ToString());

            customStack.Pop();
            Console.WriteLine(customStack.ToString());

            customStack.Peek();
        }
    }
}
