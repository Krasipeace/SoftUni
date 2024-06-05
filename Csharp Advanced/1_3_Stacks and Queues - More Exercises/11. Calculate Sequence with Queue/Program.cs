using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Calculate_Sequence_with_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAGIC_NUMBER = 2;
            int number = int.Parse(Console.ReadLine());

            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(number);

            List<int> numbers = new List<int>();
            numbers.Add(number);

            while (numbers.Count < 50)
            {
                int current = sequence.Dequeue();
                int first = current + 1;
                int second = (MAGIC_NUMBER * current) + 1;
                int third = MAGIC_NUMBER + current;

                sequence.Enqueue(first);
                sequence.Enqueue(second);
                sequence.Enqueue(third);

                numbers.Add(first);
                numbers.Add(second);
                numbers.Add(third);
            }
            Console.WriteLine(string.Join(" ", numbers.Take(50)));
        }
    }
}
