using System;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte elevate = byte.Parse(Console.ReadLine());
            byte capacity = byte.Parse(Console.ReadLine());
            int coursesFull = 0;

            coursesFull = elevate / capacity;
            if (elevate % capacity != 0)
            {
                coursesFull += 1;
            }
            Console.WriteLine(coursesFull);
        }
    }
}
