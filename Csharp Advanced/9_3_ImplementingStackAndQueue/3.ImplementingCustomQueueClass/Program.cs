using System;

namespace _3.ImplementingCustomQueueClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            Console.WriteLine(customQueue.ToString()); 

            customQueue.Dequeue();
            Console.WriteLine(customQueue.ToString());
            customQueue.Enqueue(4);
            Console.WriteLine(customQueue.ToString());
            customQueue.Enqueue(5);
            Console.WriteLine(customQueue.ToString());
        }
    }
}
