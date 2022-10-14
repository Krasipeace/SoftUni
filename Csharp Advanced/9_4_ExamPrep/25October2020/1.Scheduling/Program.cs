using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Scheduling
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Peek() != taskToKill)
            {
                if (tasks.Peek() <= threads.Peek())
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
