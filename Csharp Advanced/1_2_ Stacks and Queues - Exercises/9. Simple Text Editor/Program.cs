using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(text.ToString());

            int operations = int.Parse(Console.ReadLine());
            for (int i = 0; i < operations; i++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int action = int.Parse(commands[0]);

                switch (action)
                {
                    case 1:
                        Append(text, stack, commands);
                        break;
                    case 2:
                        Erase(text, stack, commands);
                        break;
                    case 3:
                        Returns(text, commands);
                        break;
                    case 4:
                        text = Undoes(text, stack);
                        break;
                }
            }
        }

        private static void Append(StringBuilder text, Stack<string> stack, string[] commands)
        {
            text.Append(commands[1]);
            stack.Push(text.ToString());
        }

        private static void Erase(StringBuilder text, Stack<string> stack, string[] commands)
        {
            int count = int.Parse(commands[1]);
            text.Remove(text.Length - count, count);
            stack.Push(text.ToString());
        }

        private static void Returns(StringBuilder text, string[] commands)
        {
            int index = int.Parse(commands[1]);
            Console.WriteLine(text[index - 1]);
        }
        private static StringBuilder Undoes(StringBuilder text, Stack<string> stack)
        {
            if (stack.Count != 0)
            {
                stack.Pop();
                text = new StringBuilder();
                text.Append(stack.Peek());
            }

            return text;
        }
    }
}
