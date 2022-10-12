using System;
using System.Linq;

namespace _3.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> customStack = new CustomStack<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Push":
                        string[] addElement = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                        customStack.Push(addElement);
                        break;
                    case "Pop":
                        if (customStack.Count != 0)
                        {
                            customStack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("No elements");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            PrintStack(customStack);
        }

        static void PrintStack(CustomStack<string> customStack)
        {
            foreach (var item in customStack)
            {
                Console.WriteLine(item.Replace(",", " "));
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item.Replace(",", " "));
            }
        }
    }
}
