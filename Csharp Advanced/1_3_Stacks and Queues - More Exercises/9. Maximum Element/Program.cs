using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Maximum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] command = Console.ReadLine().Split();
                int mainCommand = int.Parse(command[0]);

                switch(mainCommand)
                {
                    case 1: 
                        int pushNumber = int.Parse(command[1]);
                        numbers.Push(pushNumber);
                        break;
                    case 2: 
                        numbers.Pop();
                        break;
                    case 3: 
                        Console.WriteLine($"{numbers.Max()}");
                        break;
                }
            }
        }
    }
}
